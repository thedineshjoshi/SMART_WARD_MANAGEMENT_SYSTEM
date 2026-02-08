using Application.Common.Interfaces;
using Domain.Enumerators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceRequest.Commands
{
    public class ReviewServiceRequestCommandHandler:IRequestHandler<ReviewServiceRequestCommand>
    {
        private readonly IApplicationDbContext _context;

        public ReviewServiceRequestCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(
            ReviewServiceRequestCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.ServiceRequests
                .FirstOrDefaultAsync(x => x.ServiceRequestId == request.ServiceRequestId);

            if (entity == null)
                throw new Exception("Service request not found");

            if (entity.Status == ApprovalStatusEnum.Pending &&
                request.Status == ApprovalStatusEnum.Approved)
                throw new Exception("Must review before approval");

            entity.Status = request.Status;
            entity.Remarks = request.Remarks;
            entity.AssignedOfficerId = request.OfficerId;

            if (request.Status == ApprovalStatusEnum.Approved ||
                request.Status == ApprovalStatusEnum.Rejected)
            {
                entity.ApprovedByUserId = request.OfficerId;
                entity.ApprovedAt = DateTime.UtcNow;
            }

            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            
        }

    }
}
