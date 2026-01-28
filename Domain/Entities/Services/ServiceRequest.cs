using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Services
{
    public class ServiceRequest
    {
        public Guid ServiceRequestId { get; set; }
        public Guid UserId { get; set; }
        public string ServiceType { get; set; }
        public string ApplicationNumber { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public string RequestedWard { get; set; }
        public string RequestedMunicipality { get; set; }
        public PriorityLevelEnum PriorityLevel { get; set; }
        public Guid CurrentStatusId { get; set; }
        public Guid AssignedOfficerId { get; set; }
        public string SubmissionMode { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ApprovalLevel { get; set; }
        public Guid ApprovedBy { get; set; }
        public ApprovalStatusEnum ApprovalStatus { get; set; }
        public string Remarks { get; set; }
        public DateTime ApprovedAt { get; set; }

    }
}
