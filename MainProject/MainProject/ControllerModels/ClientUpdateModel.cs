using System.ComponentModel.DataAnnotations;

namespace MainProject.ControllerModels
{
    public class ClientUpdateModel : ClientModel
    {
        [Required]
        public int Id { get; set; }
    }
}
