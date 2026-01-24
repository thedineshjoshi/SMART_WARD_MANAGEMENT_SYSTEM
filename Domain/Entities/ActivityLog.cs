using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActivityLog
    {
        public Guid ActivityID { get; set; }
        public string UserId { get; set; }          
        public string UserFullName { get; set; }    
        public string Action { get; set; }          
        public string Module { get; set; }          
        public string IpAddress { get; set; }       
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
