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
    public class StatusMasterConfiguration
    : IEntityTypeConfiguration<StatusMaster>
    {
        public void Configure(EntityTypeBuilder<StatusMaster> builder)
        {
            builder.HasKey(x => x.StatusId);

            builder.Property(x => x.StatusCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.StatusName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(250);

            builder.HasIndex(x => x.StatusCode)
                   .IsUnique();
        }
    }

}
