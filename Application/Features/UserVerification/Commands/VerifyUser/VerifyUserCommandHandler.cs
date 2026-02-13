using Application.Common.Interfaces;
using Domain.Enumerators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserVerification.Commands.VerifyUser
{
    public class VerifyUserCommandHandler
        : IRequestHandler<VerifyUserCommand, bool>
    {
        private readonly IApplicationDbContext _db;

        public VerifyUserCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(
            VerifyUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
                throw new Exception("User not found");

            user.VerificationStatus = request.VerificationStatus;
            user.IsVerified = request.VerificationStatus == VerificationStatusEnum.Approved;
            user.VerifiedBy = request.VerifiedBy;
            user.VerifiedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
