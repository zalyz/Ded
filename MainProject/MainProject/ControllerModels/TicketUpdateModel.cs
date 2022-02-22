using System.ComponentModel.DataAnnotations;

namespace MainProject.ControllerModels
{
    public class TicketUpdateModel : TicketModel
    {
        [Required]
        public int Id { get; set; }
    }
}
