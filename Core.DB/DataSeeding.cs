using Core.Infastracture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB
{
    public static class DataSeeding
    {
        public static void SeedData(this ApplicationContext context)
        {
            Client client1 = new Client()
            {
                Name = "Leo",
                Surname = "LeoSurname",                
                City="City 1",
                Age=12,
            };
            Client client2 = new Client()
            {
                Name = "Kent",
                Surname = "KentSurname"
            };

            TimeKeeper timeKeeper1 = new TimeKeeper()
            {
                Name = "Timekeeper 1",
                Surname = "Timekeeper 1 Surname",
                Clients = new List<Client>() { client1 }
            };
            TimeKeeper timeKeeper2 = new TimeKeeper()
            {
                Name = "Timekeeper 2",
                Surname = "Timekeeper 2 Surname",
                Clients = new List<Client>() { client2 }
            };

            TimeEntry timeEntry1 = new TimeEntry()
            {
                InternalComment = "Comment for internal use",
                Language = "EN-en",
                Note = "Time entry narrative",
                Office = "Time entry address",
                StartTime = new DateTime(2020, 5, 8, 15, 15, 15),
                EndTime = new DateTime(2020, 5, 8, 17, 15, 15),
                TimeKeeper = timeKeeper1,
                WorkTime = "00:00:00",
                TimeType = TimeType.Hourly,
                Client = client1
            };
            TimeEntry timeEntry2 = new TimeEntry()
            {
                InternalComment = "Comment for internal use",
                Language = "EN-en",
                Note = "Time entry narrative",
                Office = "Time entry address",
                StartTime = new DateTime(2020, 5, 7, 15, 15, 15),
                EndTime = new DateTime(2020, 5, 7, 17, 15, 15),
                TimeKeeper = timeKeeper2,
                WorkTime = "00:00:00",
                TimeType = TimeType.Hourly,
                Client = client2
            };

            context.TimeEntries.AddRange(timeEntry1, timeEntry2);
            context.SaveChanges();
        }
    }
}
