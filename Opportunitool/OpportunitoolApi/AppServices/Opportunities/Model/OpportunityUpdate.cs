using System;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    public class OpportunityUpdate : IEquatable<OpportunityUpdate>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public DateTime? RegistrationDeadline { get; set; }

        public string RegistrationLink { get; set; }

        public string OrganizerName { get; set; }

        public string OrganizerPhone { get; set; }

        public string OrganizerEmail { get; set; }

        public bool Equals(OpportunityUpdate other)
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
                   Country == other.Country &&
                   County == other.County &&
                   City == other.City &&
                   Adress == other.Adress &&
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
                && Equals((OpportunityUpdate)obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Description);
            hash.Add(Country);
            hash.Add(County);
            hash.Add(City);
            hash.Add(Adress);
            hash.Add(RegistrationDeadline);
            hash.Add(RegistrationLink);
            hash.Add(OrganizerName);
            hash.Add(OrganizerPhone);
            hash.Add(OrganizerEmail);
            return hash.ToHashCode();
        }

        public static bool operator ==(OpportunityUpdate left, OpportunityUpdate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OpportunityUpdate left, OpportunityUpdate right)
        {
            return !Equals(left, right);
        }
    }
}