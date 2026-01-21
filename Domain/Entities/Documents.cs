using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Documents
    {
        public Guid DocumentId { get; set; }
        public Guid ReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public string FilePath { get; set; }
        public string QRHash { get; set; }
        public string DigitalSignature { get; set; }
        public string IsVerified { get; set; }
        public string VerifiedBy { get; set; }
        public DateTime VerifiedAt { get; set; }

    }
}
