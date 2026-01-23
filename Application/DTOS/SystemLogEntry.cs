using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    internal class SystemLogEntry
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Level { get; set; } // Info, Warning, Error
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
