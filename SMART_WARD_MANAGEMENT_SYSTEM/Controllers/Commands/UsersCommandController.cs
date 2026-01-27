using Application.Common.Interfaces;
using Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Commands
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UsersCommandController : ApiControllerBase
    {
        private readonly IApplicationDbContext _dbcontext;
        public UsersCommandController(IApplicationDbContext _dbcontext)
        {
            this._dbcontext = _dbcontext;
        }
        [HttpPost("CreateUser")]
        public async Task<Guid> CreateUser([FromBody]CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command,cancellationToken);
        }
    }
}
