using Application.Features.Notices.Queries.GetAllNotices;
using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Queries
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticesQueryController : ApiControllerBase
    {
        // GET: api/NoticesQuery
        [HttpGet]
        public async Task<List<Notice>> GetAllNotices(
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(
                new GetAllNoticesQuery(),
                cancellationToken);
        }
    }
}
