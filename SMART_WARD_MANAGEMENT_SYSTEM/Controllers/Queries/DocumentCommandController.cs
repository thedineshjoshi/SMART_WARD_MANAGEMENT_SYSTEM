using Application.Features.Document.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers.Queries
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentCommandController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Citizen")]
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload([FromForm] UploadDocumentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        // 📌 Ward staff verifies document
        [Authorize(Roles = "WardStaff,Admin")]
        [HttpPut("{id}/verify")]
        public async Task<IActionResult> Verify(Guid id)
        {
            var verifierId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _mediator.Send(new VerifyDocumentCommand
            {
                DocumentId = id,
                VerifiedByUserId = verifierId
            });

            return NoContent();
        }
    }
}
