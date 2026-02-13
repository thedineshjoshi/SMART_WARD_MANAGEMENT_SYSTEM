using MediatR;
using System;

namespace Application.Features.Notices.Commands.DeleteNotice
{
    public class DeleteNoticeCommand : IRequest<bool>
    {
        public Guid NoticeId { get; set; }
    }
}
