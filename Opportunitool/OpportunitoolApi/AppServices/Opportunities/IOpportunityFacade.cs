using OpportunitoolApi.AppServices.Opportunities.Model;
using OpportunitoolApi.Core.Models;
using System.Collections.Generic;

namespace OpportunitoolApi.AppServices.Opportunities
{
    /// <summary>
    /// Interface providing contracts for <see cref="Opportunity"/> related operations.
    /// </summary>
    public interface IOpportunityFacade
    {
        /// <summary>
        /// Gets opportunities.
        /// </summary>
        /// <returns>All the opportunities.</returns>
        IEnumerable<Opportunity> GetOpportunities();

        /// <summary>
        /// Creates multiple opportunities.
        /// </summary>
        /// <param name="opportunities">Opportunities to create.</param>
        /// <returns>Operation results.</returns>
        CreateOpportunitiesResult CreateOpportunities(IEnumerable<OpportunityCreate> opportunities);

        /// <summary>
        /// Updates multiple opportunities.
        /// </summary>
        /// <param name="opportunities">Opportunities to update.</param>
        /// <returns>Operation results.</returns>
        UpdateOpportunitiesResult UpdateOpportunities(IEnumerable<OpportunityUpdate> opportunities);

        /// <summary>
        /// Deletes multiple opportunities.
        /// </summary>
        /// <param name="opportunityIds">Opportunity ids to delete.</param>
        /// <returns>Operation results.</returns>
        DeleteOpportunitiesResult DeleteOpportunities(IEnumerable<long> opportunityIds);

        /// <summary>
        /// Gets multiple opportunities with the given ids.
        /// </summary>
        /// <param name="opportunityIds">Opportunities ids to get.</param>
        /// <returns>Found opportunities.</returns>
        IEnumerable<Opportunity> GetOpportunitiesByIds(IEnumerable<long> opportunityIds);

        /// <summary>
        /// Queries for opportunities matching the given <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter to be applied.</param>
        /// <returns>Opportunities matching the given filter.</returns>
        QueryOpportunitiesResult QueryOpportunities(string filter);
    }
}