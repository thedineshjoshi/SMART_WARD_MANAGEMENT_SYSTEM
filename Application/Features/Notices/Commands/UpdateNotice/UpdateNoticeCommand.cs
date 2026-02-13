using Domain.Enumerators;
using MediatR;
using System;

namespace Application.Features.Notices.Commands.UpdateNotice
{
    public class UpdateNoticeCommand : IRequest<bool>
    {
        public Guid NoticeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public NoticeTypeEnum NoticeType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsUrgent { get; set; }
    }
}
