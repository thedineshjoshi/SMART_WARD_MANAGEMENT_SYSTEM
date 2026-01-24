using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class AuditLogEntry
    {
        public string EntityName { get; set; } 
        public string EntityId { get; set; }
        public string Changes { get; set; } 
        public string ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }
}
