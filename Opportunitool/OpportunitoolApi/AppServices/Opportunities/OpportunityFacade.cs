using OpportunitoolApi.AppServices.Opportunities.Model;
using OpportunitoolApi.Core.Models;
using OpportunitoolApi.Infrastructure.Mapper;
using OpportunitoolApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Expressions;

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
        public IEnumerable<string> GetAllLocations()
        {
            return GetOpportunities().Select(opportunity => opportunity.Location).Distinct();
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
        public QueryOpportunitiesResult QueryOpportunities(string filter)
        {
            var opportunities = GetOpportunities();
            var result = new QueryOpportunitiesResult();
            if (filter == null || string.IsNullOrEmpty(filter))
            {
                result.Opportunities = opportunities;
                return result;
            }

            var parameter = Expression.Parameter(typeof(Opportunity), "Opportunity");
            try
            {
                var expression = DynamicExpressionParser.ParseLambda(new[] { parameter }, null, filter).Compile();
                result.Opportunities = opportunities.Where(opportunity => (bool)expression.DynamicInvoke(opportunity));
            }
            catch (InvalidOperationException ex)
            {
                result.Error = ex.Message;
            }
            catch (ParseException ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        /// <inheritdoc/>
        public UpdateOpportunitiesResult UpdateOpportunities(IEnumerable<OpportunityUpdate> opportunities)
        {
            var updated = new List<Opportunity>();
            var notUpdated = new List<OpportunityUpdate>();
            var notFound = new List<OpportunityUpdate>();

            foreach (var opportunity in opportunities)
            {
                var existingOpportunity = _opportunityRepository.GetById(opportunity.Id);
                if (existingOpportunity == null)
                {
                    notFound.Add(opportunity);
                }
                else
                {
                    _mapper.Map(opportunity, existingOpportunity);
                    var result = _opportunityRepository.Update(existingOpportunity);
                    if (result)
                    {
                        updated.Add(existingOpportunity);
                    }
                    else
                    {
                        notUpdated.Add(opportunity);
                    }
                }
            }

            return new UpdateOpportunitiesResult(updated, notUpdated, notFound);
        }
    }
}