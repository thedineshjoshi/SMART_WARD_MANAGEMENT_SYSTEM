using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Notices.Queries.GetAllNotices
{
    public class GetAllNoticesQueryHandler
        : IRequestHandler<GetAllNoticesQuery, List<Notice>>
    {
        private readonly IApplicationDbContext _db;

        public GetAllNoticesQueryHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Notice>> Handle(
            GetAllNoticesQuery request,
            CancellationToken cancellationToken)
        {
            return await _db.Notices
                .ToListAsync(cancellationToken);
        }
    }
}
