using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string EmployeeId { get; set; }
        public string Department { get; set; }
        public int WardNumber { get; set; }
        public Guid RoleId { get; set; }
    }
}