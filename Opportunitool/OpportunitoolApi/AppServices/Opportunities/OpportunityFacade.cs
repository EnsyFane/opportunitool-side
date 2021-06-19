using OpportunitoolApi.AppServices.Opportunities.Model;
using OpportunitoolApi.Core.Models;
using OpportunitoolApi.Infrastructure.Mapper;
using OpportunitoolApi.Persistence.Repositories;
using System.Collections.Generic;

namespace OpportunitoolApi.AppServices.Opportunities
{
    public class OpportunityFacade : IOpportunityFacade
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IMappingCoordinator _mapper;

        public OpportunityFacade(IOpportunityRepository opportunityRepository, IMappingCoordinator mapper)
        {
            _opportunityRepository = opportunityRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public CreateOpportunitiesResult CreateOpportunities(IEnumerable<OpportunityCreate> opportunities)
        {
            var created = new List<Opportunity>();
            var notCreated = new List<OpportunityCreate>();

            foreach (var opportunity in opportunities)
            {
                var opportunityModel = _mapper.Map<OpportunityCreate, Opportunity>(opportunity);
                var result = _opportunityRepository.Add(opportunityModel);
                if (result)
                {
                    created.Add(opportunityModel);
                }
                else
                {
                    notCreated.Add(opportunity);
                }
            }

            return new CreateOpportunitiesResult(created, notCreated);
        }

        /// <inheritdoc/>
        public DeleteOpportunitiesResult DeleteOpportunities(IEnumerable<long> opportunityIds)
        {
            var deleted = new List<long>();
            var notFound = new List<long>();

            foreach (var opportunityId in opportunityIds)
            {
                var opportunity = _opportunityRepository.GetById(opportunityId);
                if (opportunity != null)
                {
                    var result = _opportunityRepository.Delete(opportunity);
                    if (result)
                    {
                        deleted.Add(opportunityId);
                    }
                    else
                    {
                        notFound.Add(opportunityId);
                    }
                }
                else
                {
                    notFound.Add(opportunityId);
                }
            }

            return new DeleteOpportunitiesResult(deleted, notFound);
        }

        /// <inheritdoc/>
        public IEnumerable<Opportunity> GetOpportunities()
        {
            return _opportunityRepository.GetAll();
        }

        /// <inheritdoc/>
        public IEnumerable<Opportunity> GetOpportunitiesByIds(IEnumerable<long> opportunityIds)
        {
            var opportunities = new List<Opportunity>();

            foreach (var opportunityId in opportunityIds)
            {
                var opportunity = _opportunityRepository.GetById(opportunityId);
                if (opportunity != null)
                {
                    opportunities.Add(opportunity);
                }
            }

            return opportunities;
        }

        /// <inheritdoc/>
        public UpdateOpportunitiesResult UpdateOpportunities(IEnumerable<OpportunityUpdate> opportunities)
        {
            var updated = new List<Opportunity>();
            var notUpdated = new List<OpportunityUpdate>();
            var notFound = new List<OpportunityUpdate>();

            foreach (var opportunity in opportunities)
            {
                var opportunityModel = _mapper.Map<OpportunityUpdate, Opportunity>(opportunity);
                try
                {
                    var result = _opportunityRepository.Update(opportunityModel);
                    if (result)
                    {
                        updated.Add(opportunityModel);
                    }
                    else
                    {
                        notUpdated.Add(opportunity);
                    }
                }
                catch (KeyNotFoundException)
                {
                    notFound.Add(opportunity);
                }
            }

            return new UpdateOpportunitiesResult(updated, notUpdated, notFound);
        }
    }
}