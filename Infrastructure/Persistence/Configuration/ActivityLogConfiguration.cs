using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class ActivityLogConfiguration 
    {
        //public void Configure(EntityTypeBuilder<ActivityLog> builder)
        //{
        //    builder.HasKey(x => x.ActivityID);

        //    builder.HasOne<User>()
        //           .WithMany()
        //           .HasForeignKey(x => x.UserId)
        //           .OnDelete(DeleteBehavior.Restrict);

        //}
    }

}
