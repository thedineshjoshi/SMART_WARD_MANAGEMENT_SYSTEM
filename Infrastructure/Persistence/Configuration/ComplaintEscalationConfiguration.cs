using Domain.Entities.Services.Complaints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
   public class ComplaintEscalationConfiguration 
    : IEntityTypeConfiguration<ComplaintEscalation>
{
        public void Configure(EntityTypeBuilder<ComplaintEscalation> builder)
        {
            builder.HasKey(x => x.EscalationId);

            builder.HasOne<Complaint>()
                   .WithMany()
                   .HasForeignKey(x => x.ComplaintId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
