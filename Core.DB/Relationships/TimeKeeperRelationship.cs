using Core.Infastracture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB.Relationships
{
    public static class TimeKeeperRelationship
    {
        public static void ConfigureTimeKeeperRelationship(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeKeeper>()
                .HasMany(t => t.Clients)
                .WithOne(c => c.TimeKeeper).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TimeKeeper>()
                .HasMany(t => t.TimeEntries)
                .WithOne(t => t.TimeKeeper).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
