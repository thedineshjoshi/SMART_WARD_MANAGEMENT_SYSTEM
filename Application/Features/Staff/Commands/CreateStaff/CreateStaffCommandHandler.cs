using Application.Common.Interfaces;
using Domain.Entities.Identity;
using Domain.Enumerators;
using MediatR;

namespace Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, Guid>
    {
        private readonly IApplicationDbContext _db;

        public CreateStaffCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = new User
            {
                UserId = Guid.NewGuid(),
                UserName = request.UserName,
                Email = request.Email,
                FullNameEnglish = request.FullName,
                PhoneNumber = request.MobileNumber,
                EmployeeId = request.EmployeeId,
                Department = request.Department,
                WardNumber = request.WardNumber.ToString(),
                RoleId = request.RoleId,
                IsVerified = true,
                VerificationStatus = VerificationStatusEnum.Approved,
                AccountStatus = "Active",

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _db.Users.Add(staff);
            await _db.SaveChangesAsync(cancellationToken);
            return staff.UserId;
        }
    }
}