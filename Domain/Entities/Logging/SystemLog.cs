using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Logging
{
    public class SystemLog
    {
        public Guid Id { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Source { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
