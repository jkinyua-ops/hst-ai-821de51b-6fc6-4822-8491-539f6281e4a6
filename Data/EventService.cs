using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.Data
{
    public class EventService
    {
        private List<Event> events = new List<Event>
        {
            new Event { Id = 1, Name = "Concert A", Date = DateTime.Now.AddDays(30), Price = 50.00m },
            new Event { Id = 2, Name = "Theater Show B", Date = DateTime.Now.AddDays(45), Price = 75.00m },
            // Add more events as needed
        };

        public Task<List<Event>> GetEventsAsync()
        {
            return Task.FromResult(events);
        }

        public Task<Event> GetEventAsync(int id)
        {
            return Task.FromResult(events.FirstOrDefault(e => e.Id == id));
        }
    }
}