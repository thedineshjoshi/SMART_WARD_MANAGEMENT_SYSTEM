using Domain.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<Guid>
    {
        public string FullNameNepali { get; set; }
        public string FullNameEnglish { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CitizenshipNumber { get; set; }
        public string CitizenshipIssuedDistrict { get; set; }
        public DateTime CitizenshipIssuedDate { get; set; }
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
       
    }
}
