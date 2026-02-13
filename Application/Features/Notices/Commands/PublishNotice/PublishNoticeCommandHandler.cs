using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Common;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Features.Notices.Commands.PublishNotice
{
    public class PublishNoticeCommandHandler
        : IRequestHandler<PublishNoticeCommand, Guid>
    {
        private readonly IApplicationDbContext _db;
        private readonly IFileStorageService _fileStorage;
        public PublishNoticeCommandHandler(
            IApplicationDbContext db, IFileStorageService fileStorage)
        {
            _db = db;
            _fileStorage = fileStorage;
        }

        public async Task<Guid> Handle(
    PublishNoticeCommand request,
    CancellationToken cancellationToken)
        {
            string? filePath = null;
            string? fileType = null;

            if (request.NoticeFile != null)
            {
                var extension = Path.GetExtension(request.NoticeFile.FileName).ToLower();
                fileType = extension.Replace(".", "");

                var folder = extension == ".pdf" ? "pdf" : "images";

                filePath = await _fileStorage.SaveAsync(request.NoticeFile, folder);
            }

            var notice = new Notice
            {
                NoticeId = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                NoticeType = request.NoticeType,
                IssuedBy = request.IssuedBy,
                IssuedDate = DateTime.UtcNow,
                ExpiryDate = request.ExpiryDate,
                IsUrgent = request.IsUrgent,
                FilePath = filePath,
                FileType = fileType
            };

            _db.Notices.Add(notice);
            await _db.SaveChangesAsync(cancellationToken);

            return notice.NoticeId;
        }
    }
}
