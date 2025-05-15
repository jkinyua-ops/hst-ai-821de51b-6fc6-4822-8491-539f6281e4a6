using System;

namespace TicketingApp.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        // Add any other properties you need for your Event
    }
}