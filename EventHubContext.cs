using EntityFramework02.Configurations;
using EntityFramework02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework02
{
    internal class EventHubContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());

            // Fluent API directly inside OnModelCreating
            modelBuilder.Entity<Badge>(builder =>
            {
                builder.HasKey(b => b.BadgeId);
                builder.Property(b => b.BadgeNumber).IsRequired().HasMaxLength(50);
                builder.HasIndex(b => b.BadgeNumber).IsUnique();
                builder.Property(b => b.IssuedDate).IsRequired();
                builder.Property(b => b.Tier).IsRequired();
                builder.HasIndex(b => b.AttendeeId).IsUnique();
                builder.HasOne(b => b.Attendee).WithOne(a => a.Badge)
                    .HasForeignKey<Badge>(b => b.AttendeeId).IsRequired();
            });
        }
    }
}
