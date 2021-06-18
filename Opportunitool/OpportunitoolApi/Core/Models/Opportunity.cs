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

        /// <summary>
        /// The registration deadline.
        /// </summary>
        /// <remarks>
        /// If left empty then there is no deadline.
        /// </remarks>
        [DataType(DataType.Date)]
        public DateTime? RegistrationDeadline { get; set; }

        /// <summary>
        /// The registration link.
        /// </summary>
        /// <remarks>
        /// If left empty then there is no link.
        /// </remarks>
        [DataType(DataType.Url)]
        public string RegistrationLink { get; set; }

        [Required]
        public string OrganizerName { get; set; }

        /// <summary>
        /// The phone number of the organizer.
        /// </summary>
        /// <remarks>
        /// If left empty then the organizer didn't leave a phone number.
        /// </remarks>
        [DataType(DataType.PhoneNumber)]
        public string OrganizerPhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string OrganizerEmail { get; set; }
    }
}