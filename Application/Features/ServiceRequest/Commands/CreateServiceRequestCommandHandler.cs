using Application.Common.Interfaces;
using Domain.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceRequest.Commands
{
    public class CreateServiceRequestCommandHandler:IRequestHandler<CreateServiceRequestCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateServiceRequestCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
        CreateServiceRequestCommand request,
        CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.ServiceRequest
            {
                ServiceRequestId = Guid.NewGuid(),
                UserId = request.UserId,

                ServiceType = request.ServiceType,
                Purpose = request.Purpose,
                Description = request.Description,

                RequestedWard = request.RequestedWard,
                RequestedMunicipality = request.RequestedMunicipality,

                PriorityLevel = request.PriorityLevel,
                Status = ApprovalStatusEnum.Pending,

                SubmissionMode = "Online",
                PaymentStatus = "Pending",

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.ServiceRequests.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.ServiceRequestId;
        }
    }
}
