using System;

namespace MainProject.DTO
{
    public class TicketDto
    {
        public long Id { get; set; }

        public long FlightNumber { get; set; }

        public long ClientId { get; set; }

        public DateTime DepartureDate { get; set; }

        public int Price { get; set; }
    }
}
