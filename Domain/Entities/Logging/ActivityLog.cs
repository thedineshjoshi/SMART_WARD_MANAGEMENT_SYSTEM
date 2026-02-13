using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Logging
{
    public class ActivityLog
    {
        [Key] public Guid ActivityID { get; set; }
        public Guid UserId { get; set; }
        public string UserFullName { get; set; }
        public string Action { get; set; }
        public string Module { get; set; }
        public string IpAddress { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
