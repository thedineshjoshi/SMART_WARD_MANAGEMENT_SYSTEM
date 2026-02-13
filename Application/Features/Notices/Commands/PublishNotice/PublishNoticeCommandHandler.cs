using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;

        public PublishNoticeCommandHandler(
            IApplicationDbContext db,
            IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
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

                var fileName = $"notice_{Guid.NewGuid()}{extension}";
                var savePath = Path.Combine(
                    _env.WebRootPath,
                    "notices",
                    folder,
                    fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using var stream = new FileStream(savePath, FileMode.Create);
                await request.NoticeFile.CopyToAsync(stream, cancellationToken);

                filePath = $"/notices/{folder}/{fileName}";
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
