using Application.DTOS;
using Application.Interfaces;
using MediaBrowser.Model.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public class FileActivityLogger : IActivityLogger
    {
        public async Task LogActivity(ActivityLogEntry entry)
        {
            // Implementation: Writing to a local file for the Ward Management System
            //string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WardActivity.log");
            //string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | User: {entry.UserId} | Action: {entry.Action} | Module: {entry.Module}{Environment.NewLine}";

            //await File.AppendAllTextAsync(logPath, logLine);
        }
    }
}