using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ComplaintEscalation
    {
        public Guid EscalationId { get; set; }
        public Guid ComplaintId { get; set; }
        public string EscalatedFrom { get; set; }
        public string EscalatedTo { get; set; }
        public string Reason { get; set; }
        public DateTime EscalatedAt { get; set; }

    }
}
