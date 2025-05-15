using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.Data
{
    public class EventService
    {
        private List<Event> _events;

        public EventService()
        {
            _events = new List<Event>
            {
                new Event { Id = 1, Name = "Summer Concert", Description = "A night of great music", Date = DateTime.Now.AddDays(30), Price = 50.00m, AvailableTickets = 100 },
                new Event { Id = 2, Name = "Comedy Show", Description = "Laugh out loud with top comedians", Date = DateTime.Now.AddDays(45), Price = 35.00m, AvailableTickets = 50 },
                new Event { Id = 3, Name = "Tech Conference", Description = "Learn about the latest in technology", Date = DateTime.Now.AddDays(60), Price = 150.00m, AvailableTickets = 200 }
            };
        }

        public Task<List<Event>> GetEventsAsync()
        {
            return Task.FromResult(_events);
        }

        public Task<Event> GetEventAsync(int id)
        {
            return Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
        }

        public Task<bool> BookEventAsync(int id)
        {
            var eventToBook = _events.FirstOrDefault(e => e.Id == id);
            if (eventToBook != null && eventToBook.AvailableTickets > 0)
            {
                eventToBook.AvailableTickets--;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}