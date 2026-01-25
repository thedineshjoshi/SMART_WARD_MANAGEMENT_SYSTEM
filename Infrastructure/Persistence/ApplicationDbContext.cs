using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext:DbContext,IApplicationDbContext
    {
        public ApplicationDbContext()
        { } 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<AuditLogs> AuditLogs { get; set; }
        public DbSet<CitizenVerificationRequest> CitizenVerificationRequests { get; set; }
        public DbSet<ComplaintEscalations> ComplaintEscalations { get; set; }
        public DbSet<Complaints> Complaints { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Notices> Notices { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ServiceApprovalFlow>ServiceApprovalFlows { get; set; }
        public DbSet<ServiceRequest>ServiceRequests { get; set; }
        public DbSet<StatusHistory> StatusHistories { get; set; }
        public DbSet<StatusMaster> StatusMasters { get; set; }
        public DbSet<User> UsersDetails { get; set; }
        public DbSet<SignUp> Users { get; set; }
    }
}
