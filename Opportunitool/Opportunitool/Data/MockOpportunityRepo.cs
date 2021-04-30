using Opportunitool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opportunitool.Data
{
    public class MockOpportunityRepo : IOpportunityRepo
    {
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
    }
}