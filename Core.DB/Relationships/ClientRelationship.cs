using Core.Infastracture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB.Relationships
{
    public static class ClientRelationship
    {
        public static void ConfigureClientRelationship(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(t => t.TimeEntries)
                .WithOne(te => te.Client)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
