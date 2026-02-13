using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceRequest.Queries
{
    public class GetMyServiceRequestsQueryHandler
    : IRequestHandler<GetMyServiceRequestsQuery, List<Domain.Entities.Services.ServiceRequest>>
    {
        private readonly IApplicationDbContext _context;

        public GetMyServiceRequestsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Services.ServiceRequest>> Handle(
            GetMyServiceRequestsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.ServiceRequests
                .Where(x => x.UserId == request.UserId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
