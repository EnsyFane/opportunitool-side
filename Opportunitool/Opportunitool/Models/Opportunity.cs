using System.ComponentModel.DataAnnotations;

namespace Opportunitool.Models
{
    public class Opportunity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Organizer { get; set; }
    }
}