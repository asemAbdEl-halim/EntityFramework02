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
    public class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.OrganizerProfileId);
            builder.Property(p => p.Biography).HasMaxLength(1000);
            builder.Property(p => p.Website).HasMaxLength(300);
            builder.Property(p => p.LogoUrl).HasMaxLength(500);
            builder.HasOne(p => p.Organizer).WithOne(o => o.Profile)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId).IsRequired();
        }
    }
}
