using Domain.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceRequest.Commands
{
    public class ReviewServiceRequestCommand : IRequest
    {
        public Guid ServiceRequestId { get; set; }
        public ApprovalStatusEnum Status { get; set; }
        public string? Remarks { get; set; }
        public Guid OfficerId { get; set; }
    }
}
