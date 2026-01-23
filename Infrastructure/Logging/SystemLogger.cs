using Application.DTOS;
using Application.Interfaces;
using MediaBrowser.Model.Activity;
using Microsoft.VisualStudio.Services.Organization.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public class SerilogSystemLogger : ISystemLogger
    {
        public async Task LogError(string message, Exception ex)
        {
            // Implementation body
            // This writes the error to the Serilog sink (Console, File, etc.)
            //Log.Error(ex, "Ward System Failure: {Message}", message);
            //await Task.CompletedTask;
        }

        public async Task LogInfo(string message)
        {
            //Log.Information("Ward System Update: {Message}", message);
            //await Task.CompletedTask;
        }
    }
}
