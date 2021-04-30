using System.ComponentModel.DataAnnotations;

namespace Opportunitool.Dtos
{
    public class OpportunityUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Organizer { get; set; }
    }
}