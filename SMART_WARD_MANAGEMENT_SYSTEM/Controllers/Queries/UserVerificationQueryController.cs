using Application.Features.UserVerification.Queries.GetPendingVerificationUsers;
using Application.Features.UserVerification.Queries.GetUserVerificationDetails;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Queries
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserVerificationQueryController : ApiControllerBase
    {
        // GET: api/UserVerificationQuery/PendingUsers
        [HttpGet("PendingUsers")]
        public async Task<List<User>> GetPendingUsers(
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(
                new GetPendingVerificationUsersQuery(),
                cancellationToken);
        }

        // GET: api/UserVerificationQuery/UserDetails/{userId}
        [HttpGet("UserDetails/{userId}")]
        public async Task<User> GetUserDetails(
            Guid userId,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(
                new GetUserVerificationDetailsQuery
                {
                    UserId = userId
                },
                cancellationToken);
        }
    }
}
