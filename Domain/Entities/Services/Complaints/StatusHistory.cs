using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Services.Complaints
{
    public class StatusHistory
    {
        public Guid HistoryId { get; set; }
        public Guid ReferenceId { get; set; }
        public ReferenceTypeEnum ReferenceType { get; set; }
        public Guid OldStatusId { get; set; }
        public Guid NewStatusId { get; set; }
        public Guid ChangedBy { get; set; }
        public string ChangeReason { get; set; }
        public DateTime ChangedAt { get; set; }

    }
}
