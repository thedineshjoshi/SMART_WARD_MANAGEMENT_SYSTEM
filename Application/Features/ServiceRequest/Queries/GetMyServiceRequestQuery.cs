using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceRequest.Queries
{
    public class GetMyServiceRequestsQuery : IRequest<List<Domain.Entities.Services.ServiceRequest>>
    {
        public Guid UserId { get; set; }
    }
}
