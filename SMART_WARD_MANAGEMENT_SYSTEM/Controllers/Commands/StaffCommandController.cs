using Application.Features.Staff.Commands.CreateStaff;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Commands
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Secretary")]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateStaffCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), new { id = result }, result);
        }
    }
}
