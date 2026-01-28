using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Services.Complaints
{
    public class StatusMaster
    {
        public Guid StatusId { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
    }
}
