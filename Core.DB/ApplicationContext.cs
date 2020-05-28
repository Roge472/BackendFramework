using Core.DB.Relationships;
using Core.Infastracture.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Core.DB
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<TimeKeeper> TimeKeepers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureClientRelationship();
            modelBuilder.ConfigureTimeEntryRelationshipp();
            modelBuilder.ConfigureTimeKeeperRelationship();
        }
    }
}
