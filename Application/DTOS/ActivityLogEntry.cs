using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    internal class ActivityLogEntry
    {
        public string UserId { get; set; }
        public string Action { get; set; } // e.g., "Birth Certificate Issued"
        public string Module { get; set; } // e.g., "VitalRegistration"
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string IpAddress { get; set; }
    }
}
