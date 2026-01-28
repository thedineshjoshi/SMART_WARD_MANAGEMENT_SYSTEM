using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Identity;
using Domain.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _db;
        public CreateUserCommandHandler(IApplicationDbContext _db)
        {
            this._db = _db;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                FullNameNepali = request.FullNameNepali,
                FullNameEnglish = request.FullNameEnglish,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                CitizenshipNumber = request.CitizenshipNumber,
                CitizenshipIssuedDistrict = request.CitizenshipIssuedDistrict,
                CitizenshipIssuedDate = request.CitizenshipIssuedDate,
                NationalIdNumber = request.NationalIdNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                PermanentAddress = request.PermanentAddress,
                TemporaryAddress = request.TemporaryAddress,
                WardNumber = request.WardNumber,
                Municipality = request.Municipality,
                District = request.District,
                Province = request.Province,
                RoleId = request.RoleId,
                IsVerified = false,
                VerificationStatus = VerificationStatusEnum.Pending,
                VerifiedBy = Guid.Empty,
                VerifiedAt = null,
                AccountStatus = "Active",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancellationToken);
            return user.UserId;
        }
    }
}
