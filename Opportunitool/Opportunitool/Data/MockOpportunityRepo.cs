using Opportunitool.Models;
using System;
using System.Collections.Generic;

namespace Opportunitool.Data
{
    public class MockOpportunityRepo : IOpportunityRepo
    {
        public void CreateOpportunity(Opportunity opportunity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOpportunity(Opportunity opportunity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Opportunity> GetAllOpportunities()
        {
            return new List<Opportunity>()
            {
                new Opportunity()
                {
                    Id = 1,
                    Name = "My name",
                    Organizer = "Me"
                },
                new Opportunity()
                {
                    Id = 2,
                    Name = "Another name",
                    Organizer = "You?"
                }
            };
        }

        public Opportunity GetOpportunityById(int id)
        {
            return new Opportunity()
            {
                Id = 1,
                Name = "My name",
                Organizer = "Me"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateOpportunity(Opportunity opportunity)
        {
            throw new NotImplementedException();
        }
    }
}