using Application.Interfaces;

namespace Infrastructure.Logging
{
    public class SerilogSystemLogger : ISystemLogger
    {
        public async Task LogError(string message, Exception ex)
        {
    ;
        }

        public async Task LogInfo(string message)
        {
            
        }
    }
}
