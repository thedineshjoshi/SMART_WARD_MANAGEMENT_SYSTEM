using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FullNameNepali { get; set; }
        public string FullNameEnglish { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CitizenshipNumber { get; set; }
        public string CitizenshipIssuedDistrict { get; set; }
        public string CitizenshipIssuedDate { get; set; }
        public string NationalIdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PermanentAddress { get; set; }
        public string TemporaryAddress { get; set; }
        public string WardNumber { get; set; }
        public string Municipality { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public Guid RoleId { get; set; }
        public bool IsVerified { get; set; } = false;
        public VerificationStatusEnum VerificationStatus { get; set; }
        public Guid VerifiedBy { get; set; }
        public string VerifiedAt { get; set; }
        public string AccountStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



    }
}
