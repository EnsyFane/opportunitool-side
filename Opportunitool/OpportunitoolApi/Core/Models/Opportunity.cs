using System;
using System.ComponentModel.DataAnnotations;

namespace OpportunitoolApi.Core.Models
{
    public class Opportunity : IEquatable<Opportunity>
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

        public bool Equals(Opportunity other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id &&
                   Name == other.Name &&
                   Description == other.Description &&
                   Location == other.Location &&
                   RegistrationDeadline == other.RegistrationDeadline &&
                   RegistrationLink == other.RegistrationLink &&
                   OrganizerName == other.OrganizerName &&
                   OrganizerPhone == other.OrganizerPhone &&
                   OrganizerEmail == other.OrganizerEmail;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == GetType()
                && Equals((Opportunity)obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Description);
            hash.Add(Location);
            hash.Add(RegistrationDeadline);
            hash.Add(RegistrationLink);
            hash.Add(OrganizerName);
            hash.Add(OrganizerPhone);
            hash.Add(OrganizerEmail);
            return hash.ToHashCode();
        }

        public static bool operator ==(Opportunity left, Opportunity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Opportunity left, Opportunity right)
        {
            return !Equals(left, right);
        }
    }
}