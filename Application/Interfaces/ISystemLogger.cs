using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISystemLogger
    {
        Task LogInfo(string message);
        Task LogError(string message, Exception ex);
    }
}
