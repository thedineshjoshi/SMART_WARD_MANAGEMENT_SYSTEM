using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CitizenVerificationRequest
    {
        public Guid VerificationRequestId { get; set; }
        public Guid RequesterUserId { get; set; }
        public string CitizenshipFrontImageUrl { get; set; }
        public string CitizenshipBackImageUrl { get; set; }
        public string LivePhotoUrl { get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
        public Guid ReviewerUserId { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }
}
