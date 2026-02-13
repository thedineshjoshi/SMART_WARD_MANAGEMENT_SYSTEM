using Application.Features.ServiceRequest.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Commands
{
    [ApiController]
    [Route("api/service-requests")]
    public class ServiceRequestsCommandController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceRequestsCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Citizen")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceRequestCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [Authorize(Roles = "WardStaff,Admin")]
        [HttpPut("{id}/review")]
        public async Task<IActionResult> Review(
            Guid id,
            ReviewServiceRequestCommand command)
        {
            command.ServiceRequestId = id;
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
