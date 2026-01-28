using Domain.Entities.Identity;
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
    public class StatusHistoryConfiguration
    : IEntityTypeConfiguration<StatusHistory>
    {
        public void Configure(EntityTypeBuilder<StatusHistory> builder)
        {
            builder.HasKey(x => x.HistoryId);

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(x => x.ChangedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<StatusMaster>()
                   .WithMany()
                   .HasForeignKey(x => x.OldStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<StatusMaster>()
                   .WithMany()
                   .HasForeignKey(x => x.NewStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
