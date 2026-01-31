using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Login.Query
{
    public class LoginQuery:IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
