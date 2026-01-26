using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class ServiceApprovalFlowConfiguration
    : IEntityTypeConfiguration<ServiceApprovalFlow>
    {
        public void Configure(EntityTypeBuilder<ServiceApprovalFlow> builder)
        {
            builder.HasKey(x => x.ApprovalId);

            builder.HasOne<ServiceRequest>()
                   .WithMany()
                   .HasForeignKey(x => x.ServiceRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ServiceRequestId);
        }
    }

}
