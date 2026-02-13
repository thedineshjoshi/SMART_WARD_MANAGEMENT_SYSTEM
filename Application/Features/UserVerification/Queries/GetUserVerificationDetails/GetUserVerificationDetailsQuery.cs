using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.UserVerification.Queries.GetUserVerificationDetails
{
    public class GetUserVerificationDetailsQuery : IRequest<User>
    {
        public Guid UserId { get; set; }
    }
}
