using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Services.Complaints
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public RoleNameEnum RoleName { get; set; }

    }
}
