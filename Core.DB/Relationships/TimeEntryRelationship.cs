using Core.Infastracture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB.Relationships
{
    public static class TimeEntryRelationship
    {
        public static void ConfigureTimeEntryRelationshipp(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeEntry>()
                .HasOne(t => t.TimeKeeper)
                .WithMany(tk => tk.TimeEntries)
                .HasForeignKey(t => t.TimeKeeperID);

            modelBuilder.Entity<TimeEntry>()
                .HasOne(t => t.Client)
                .WithMany(t => t.TimeEntries)
                .HasForeignKey(t => t.ClientID);

            modelBuilder.Entity<TimeEntry>()
               .Property(t => t.TimeType)
               .HasConversion<string>();
        }
    }
}
