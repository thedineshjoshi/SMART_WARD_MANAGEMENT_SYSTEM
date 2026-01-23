using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuditLogs
    {
        public Guid AuditId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string EntityName { get; set; }      
        public string EntityId { get; set; }        
        public string Action { get; set; }         
        public string OldValues { get; set; }       
        public string NewValues { get; set; }       
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }
}
