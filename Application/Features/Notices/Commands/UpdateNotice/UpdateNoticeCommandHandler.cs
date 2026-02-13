using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Notices.Commands.UpdateNotice
{
    public class UpdateNoticeCommandHandler
        : IRequestHandler<UpdateNoticeCommand, bool>
    {
        private readonly IApplicationDbContext _db;

        public UpdateNoticeCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(
            UpdateNoticeCommand request,
            CancellationToken cancellationToken)
        {
            var notice = await _db.Notices
                .FirstOrDefaultAsync(n => n.NoticeId == request.NoticeId, cancellationToken);

            if (notice == null)
                throw new Exception("Notice not found");

            notice.Title = request.Title;
            notice.Content = request.Content;
            notice.NoticeType = request.NoticeType;
            notice.ExpiryDate = request.ExpiryDate;
            notice.IsUrgent = request.IsUrgent;

            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
