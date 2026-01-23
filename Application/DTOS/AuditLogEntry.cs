using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    internal class AuditLogEntry
    {
        public string EntityName { get; set; } // e.g., "PropertyTaxRecord"
        public string EntityId { get; set; }
        public string Changes { get; set; } // JSON serialized diff
        public string ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }
}
