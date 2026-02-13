using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Notices.Commands.DeleteNotice
{
    public class DeleteNoticeCommandHandler
        : IRequestHandler<DeleteNoticeCommand, bool>
    {
        private readonly IApplicationDbContext _db;

        public DeleteNoticeCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(
            DeleteNoticeCommand request,
            CancellationToken cancellationToken)
        {
            var notice = await _db.Notices
                .FirstOrDefaultAsync(n => n.NoticeId == request.NoticeId, cancellationToken);

            if (notice == null)
                throw new Exception("Notice not found");

            _db.Notices.Remove(notice);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
