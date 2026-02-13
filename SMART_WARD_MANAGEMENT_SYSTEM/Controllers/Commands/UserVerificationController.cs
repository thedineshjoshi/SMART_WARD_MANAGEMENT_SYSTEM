using Application.Features.UserVerification.Commands.VerifyUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Commands
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserVerificationCommandController : ApiControllerBase
    {
        // POST: api/UserVerificationCommand/VerifyUser
        [HttpPost("VerifyUser")]
        public async Task<bool> VerifyUser(
            [FromBody] VerifyUserCommand command,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
    }
}
