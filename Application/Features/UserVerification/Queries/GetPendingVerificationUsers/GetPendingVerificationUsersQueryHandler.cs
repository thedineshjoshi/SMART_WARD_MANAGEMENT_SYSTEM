using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Identity;
using Domain.Enumerators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserVerification.Queries.GetPendingVerificationUsers
{
    public class GetPendingVerificationUsersQueryHandler
        : IRequestHandler<GetPendingVerificationUsersQuery, List<User>>
    {
        private readonly IApplicationDbContext _db;

        public GetPendingVerificationUsersQueryHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<User>> Handle(
            GetPendingVerificationUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await _db.Users
                .Where(u => u.VerificationStatus == VerificationStatusEnum.Pending)
                .ToListAsync(cancellationToken);
        }
    }
}
