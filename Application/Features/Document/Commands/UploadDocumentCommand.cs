using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Document.Commands
{
    public class UploadDocumentCommand : IRequest<Guid>
    {
        public Guid ReferenceId { get; set; }    
        public string ReferenceType { get; set; }     
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }

        public IFormFile File { get; set; }
    }

}
