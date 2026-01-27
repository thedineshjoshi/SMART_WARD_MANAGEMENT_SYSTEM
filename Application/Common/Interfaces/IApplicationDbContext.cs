using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ActivityLog> ActivityLogs { get; set; }
        DbSet<AuditLog> AuditLogs { get; set; }
        DbSet<CitizenVerificationRequest> CitizenVerificationRequests { get; set; }
        DbSet<Complaint> Complaints { get; set; }
        DbSet<ComplaintEscalation> ComplaintEscalations { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<Notice> Notices { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<ServiceApprovalFlow> ServiceApprovalFlows { get; set; }
        DbSet<ServiceRequest> ServiceRequests { get; set; }
        DbSet<StatusHistory> StatusHistories { get; set; }
        DbSet<StatusMaster> StatusMasters { get; set; }
        DbSet<SystemLog> SystemLogs { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
