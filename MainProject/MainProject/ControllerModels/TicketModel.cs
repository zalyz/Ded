using System;
using System.ComponentModel.DataAnnotations;

namespace MainProject.ControllerModels
{
    public class TicketModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long FlightNumber { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
