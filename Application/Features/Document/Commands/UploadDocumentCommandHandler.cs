using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Document.Commands
{
    public class UploadDocumentCommandHandler
    : IRequestHandler<UploadDocumentCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileStorageService _fileStorage;

        public UploadDocumentCommandHandler(
            IApplicationDbContext context,
            IFileStorageService fileStorage)
        {
            _context = context;
            _fileStorage = fileStorage;
        }

        public async Task<Guid> Handle(
            UploadDocumentCommand request,
            CancellationToken cancellationToken)
        {
            var filePath = await _fileStorage.SaveAsync(
                request.File, "documents");

            var document = new Domain.Entities.Common.Document
            {
                DocumentId = Guid.NewGuid(),
                ReferenceId = request.ReferenceId,
                ReferenceType = request.ReferenceType,

                DocumentType = request.DocumentType,
                DocumentNumber = request.DocumentNumber,
                IssuedBy = request.IssuedBy,
                IssuedDate = request.IssuedDate,

                FilePath = filePath,
                IsVerified = false
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync(cancellationToken);

            return document.DocumentId;
        }
    }
}
