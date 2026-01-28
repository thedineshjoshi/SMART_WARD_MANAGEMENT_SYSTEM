using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Services
{
    public class ServiceApprovalFlow
    {
        public Guid ApprovalId { get; set; }
        public Guid ServiceRequestId { get; set; }

    }
}
