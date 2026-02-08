using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Document.Commands
{
    public class VerifyDocumentCommandHandler
    : IRequestHandler<VerifyDocumentCommand>
    {
        private readonly IApplicationDbContext _context;

        public VerifyDocumentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(
            VerifyDocumentCommand request,
            CancellationToken cancellationToken)
        {
            var document = await _context.Documents
                .FirstOrDefaultAsync(x => x.DocumentId == request.DocumentId);

            if (document == null)
                throw new Exception("Document not found");

            document.IsVerified = true;
            document.VerifiedByUserId = request.VerifiedByUserId;
            document.VerifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
