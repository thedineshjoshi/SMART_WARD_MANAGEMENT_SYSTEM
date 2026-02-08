using Domain.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceRequest.Commands
{
    public class CreateServiceRequestCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string ServiceType { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public string RequestedWard { get; set; }
        public string RequestedMunicipality { get; set; }
        public PriorityLevelEnum PriorityLevel { get; set; }
    }
}
