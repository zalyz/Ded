using System.ComponentModel.DataAnnotations;

namespace MainProject.ControllerModels
{
    public class ClientModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PassportNumber { get; set; }
    }
}
