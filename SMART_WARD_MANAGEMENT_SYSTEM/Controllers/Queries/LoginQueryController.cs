using Application.Features.Login.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Queries
{
    public class LoginQueryController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public LoginQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }

    }
}
