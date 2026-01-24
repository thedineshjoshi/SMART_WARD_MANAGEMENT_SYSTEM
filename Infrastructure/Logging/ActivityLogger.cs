using Application.DTOS;
using Application.Interfaces;
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
            
        }
    }
}