using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Complaint
    {
        public Guid ComplaintId { get; set; }
        public Guid UserId { get; set; }
        public string ComplaintNumber { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public PriorityLevelEnum PriorityLevel { get; set; } 
        public StatusMaster StatusMaster { get; set; }
        public Guid CurrentStatusId { get; set; }
        public string AssignedDepartment { get; set; }
        public string AssignedOfficer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ResolvedAt { get; set; }

    }
}
