using OpportunitoolApi.Core.Models;

namespace OpportunitoolApi.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for a <see cref="Opportunity"/> repository.
    /// </summary>
    public interface IOpportunityRepository : IGenericRepo<Opportunity, long>
    {
    }
}