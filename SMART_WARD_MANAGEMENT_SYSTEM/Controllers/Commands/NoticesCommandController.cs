using Application.Features.Notices.Commands.PublishNotice;
using Application.Features.Notices.Commands.UpdateNotice;
using Application.Features.Notices.Commands.DeleteNotice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Commands
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticesCommandController : ApiControllerBase
    {
        [HttpPost("Publish")]
        public async Task<Guid> PublishNotice(
        [FromForm] PublishNoticeCommand command,//[fromfrom] because files are uploaded as multipart/forms data
         CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }


        [HttpPut("Update")]
        public async Task<bool> UpdateNotice(
            [FromBody] UpdateNoticeCommand command,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }

        [HttpDelete("Delete/{noticeId}")]
        public async Task<bool> DeleteNotice(
            Guid noticeId,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(
                new DeleteNoticeCommand { NoticeId = noticeId },
                cancellationToken);
        }
    }
}
