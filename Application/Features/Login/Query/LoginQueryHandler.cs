using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Login.Query
{
    public class LoginQueryHandler:IRequestHandler<LoginQuery,string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtTokenService _jwt;
        public LoginQueryHandler(IApplicationDbContext context, IJwtTokenService jwt)
        {
            _context = context;
            _jwt = jwt;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
            .FirstOrDefaultAsync(x => x.UserName == request.Username);


            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid credentials");


            return _jwt.GenerateToken(user);
        }
    }
}
