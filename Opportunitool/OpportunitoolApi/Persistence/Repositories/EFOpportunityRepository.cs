using OpportunitoolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Persistence.Repositories
{
    /// <summary>
    /// Specific Entity Framework implementation of <see cref="IOpportunityRepository"/>.
    /// </summary>
    public class EFOpportunityRepository : IOpportunityRepository
    {
        private readonly OpportunitoolDbContext _dbContext;

        public EFOpportunityRepository(OpportunitoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public bool Add(Opportunity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Opportunities.Add(entity);
            return _dbContext.SaveChanges() >= 0;
        }

        /// <inheritdoc/>
        public bool Delete(Opportunity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Opportunities.Remove(entity);
            return _dbContext.SaveChanges() >= 0;
        }

        /// <inheritdoc/>
        public IEnumerable<Opportunity> GetAll()
        {
            return _dbContext.Opportunities.ToList();
        }

        /// <inheritdoc/>
        public Opportunity GetById(long id)
        {
            return _dbContext.Opportunities.FirstOrDefault(opportunity => opportunity.Id == id);
        }

        /// <inheritdoc/>
        public bool Update(Opportunity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (GetById(entity.Id.Value) != entity)
            {
                throw new KeyNotFoundException(nameof(entity));
            }

            _dbContext.Opportunities.Update(entity);
            return _dbContext.SaveChanges() >= 0;
        }
    }
}