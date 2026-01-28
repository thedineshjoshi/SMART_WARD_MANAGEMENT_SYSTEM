using Domain.Entities.Identity;
using Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class CitizenVerificationConfiguration
    : IEntityTypeConfiguration<CitizenVerificationRequest>
    {
        public void Configure(EntityTypeBuilder<CitizenVerificationRequest> builder)
        {
            builder.HasKey(x => x.VerificationRequestId);

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(x => x.RequesterUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(x => x.ReviewerUserId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
