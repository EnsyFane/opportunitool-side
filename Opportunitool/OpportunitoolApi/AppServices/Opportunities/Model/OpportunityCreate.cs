﻿using System;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    public class OpportunityCreate : IEquatable<OpportunityCreate>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime? RegistrationDeadline { get; set; }

        public string RegistrationLink { get; set; }

        public string OrganizerName { get; set; }

        public string OrganizerPhone { get; set; }

        public string OrganizerEmail { get; set; }

        public bool Equals(OpportunityCreate other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name &&
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
                && Equals((OpportunityCreate)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Location, RegistrationDeadline, RegistrationLink, OrganizerName, OrganizerPhone, OrganizerEmail);
        }

        public static bool operator ==(OpportunityCreate left, OpportunityCreate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OpportunityCreate left, OpportunityCreate right)
        {
            return !Equals(left, right);
        }
    }
}