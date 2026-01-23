using Application.DTOS;
using Application.Interfaces;
using MediaBrowser.Model.Activity;
using Microsoft.VisualStudio.Services.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public class SqlAuditLogger : IAuditLogger
    {
        // In a real app, you would inject your DbContext here
        // private readonly WardDbContext _context;

        public async Task LogChange(AuditLogEntry entry)
        {
            //// This is the "body" of the method
            //// For now, let's write to the Debug console so you can see it working
            //Console.WriteLine($"[AUDIT] Entity: {entry.EntityName} | ID: {entry.EntityId} | Changed By: {entry.ChangedBy}");

            //// Logic: _context.AuditLogs.Add(entry);
            //// await _context.SaveChangesAsync();

            //await Task.CompletedTask;
        }
    }
}
