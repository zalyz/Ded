using System.ComponentModel.DataAnnotations;

namespace MainProject.ControllerModels
{
    public class TicketModel
    {
        [Required]
        public long FlightNumber { get; set; }
    }
}
