using System;
using System.ComponentModel.DataAnnotations;

namespace OpportunitoolApi.Core.Models
{
    public class Opportunity
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RegistrationDeadline { get; set; }

        [DataType(DataType.Url)]
        public string RegistrationLink { get; set; }

        [Required]
        public string OrganizerName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string OrganizerPhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string OrganizerEmail { get; set; }
    }
}