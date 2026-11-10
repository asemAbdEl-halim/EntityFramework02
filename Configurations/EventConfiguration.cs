using EntityFramework02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework02.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.EventId);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(3000);
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.MaxAttendees).IsRequired();
            builder.HasOne(e => e.Organizer).WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId).IsRequired();
        }
    }
}
