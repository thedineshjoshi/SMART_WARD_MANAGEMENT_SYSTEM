using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers
{
    [Route("/api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
