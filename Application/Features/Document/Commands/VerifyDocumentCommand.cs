using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Document.Commands
{
    public class VerifyDocumentCommand : IRequest
    {
        public Guid DocumentId { get; set; }
        public Guid VerifiedByUserId { get; set; }
    }
}
