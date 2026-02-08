using Application.Features.ServiceRequest.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Queries
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestQueryController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceRequestQueryController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Citizen")]
        [HttpGet("my")]
        public async Task<IActionResult> MyRequests()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _mediator.Send(
                new GetMyServiceRequestsQuery { UserId = userId });

            return Ok(result);
        }

    }
}
