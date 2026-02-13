using Domain.Enumerators;
using MediatR;
using System;

namespace Application.Features.UserVerification.Commands.VerifyUser
{
    public class VerifyUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid VerifiedBy { get; set; }   // Ward Staff/Admin
        public VerificationStatusEnum VerificationStatus { get; set; }
        public string Remarks { get; set; }
    }
}
