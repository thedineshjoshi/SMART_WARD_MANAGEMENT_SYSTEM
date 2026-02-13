using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserVerification.Queries.GetUserVerificationDetails
{
    public class GetUserVerificationDetailsQueryHandler
        : IRequestHandler<GetUserVerificationDetailsQuery, User>
    {
        private readonly IApplicationDbContext _db;

        public GetUserVerificationDetailsQueryHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> Handle(
            GetUserVerificationDetailsQuery request,
            CancellationToken cancellationToken)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);
        }
    }
}
