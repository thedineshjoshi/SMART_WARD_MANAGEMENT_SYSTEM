using Domain.Enumerators;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.Features.Notices.Commands.PublishNotice
{
    public class PublishNoticeCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public NoticeTypeEnum NoticeType { get; set; }

        public Guid IssuedBy { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsUrgent { get; set; }

        public IFormFile? NoticeFile { get; set; }   //  PDF / JPG
    }
}
