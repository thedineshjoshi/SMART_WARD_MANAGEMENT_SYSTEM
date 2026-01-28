using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class WardApplicationService
    {
        private readonly IAuditLogger _auditLogger;
        private readonly IActivityLogger _activityLogger;
        private readonly ISystemLogger _systemLogger;

        public WardApplicationService(
            IAuditLogger auditLogger,
            IActivityLogger activityLogger,
            ISystemLogger systemLogger)
        {
            _auditLogger = auditLogger;
            _activityLogger = activityLogger;
            _systemLogger = systemLogger;
        }


    }
}
