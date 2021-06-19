﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpportunitoolApi.AppServices.Opportunities;
using OpportunitoolApi.Controllers.Models;
using OpportunitoolApi.Errors;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace OpportunitoolApi.Controllers
{
    [Route("opportunitool/opportunities")]
    [ApiController]
    public class OpportunityController : ControllerBase, IOpportunityController
    {
        private readonly IOpportunityFacade _opportunityFacade;

        public OpportunityController(IOpportunityFacade opportunityFacade)
        {
            _opportunityFacade = opportunityFacade;
        }

        [HttpGet("{opportunityId}")]
        [SwaggerOperation(
            Summary = "Gets an opportunity by id.",
            OperationId = "get-opportunity",
            Tags = new[] { "Opportunities" }
        )]
        [SwaggerResponse(200, "The opportunity with the given id.", typeof(GetOpportunityResponse))]
        [SwaggerResponse(404, "No opportunity with the given id was found.", typeof(GetOpportunityResponse))]
        public ActionResult<GetOpportunityResponse> GetOpportunityById([FromRoute] long opportunityId)
        {
            var opportunity = _opportunityFacade.GetOpportunitiesByIds(new long[] { opportunityId }).FirstOrDefault();
            var response = new GetOpportunityResponse();

            if (opportunity == null)
            {
                response.Errors = new Error[]
                {
                    new Error
                    {
                        ErrorCode = ErrorCodes.OpportunityNotFoundError,
                        ErrorMessage = $"No opportunity with Id: {opportunityId} found."
                    }
                };

                return NotFound(response);
            }

            response.Opportunity = opportunity;

            return Ok(response);
        }

        [HttpGet("")]
        [SwaggerOperation(
            Summary = "Gets all opportunities.",
            OperationId = "get-all-opportunities",
            Tags = new[] { "Opportunities" }
        )]
        [SwaggerResponse(200, "All opportunities stored in the app.", typeof(GetOpportunitiesResponse))]
        public ActionResult<GetOpportunitiesResponse> GetAllOpportunities()
        {
            var opportunities = _opportunityFacade.GetOpportunities();

            var response = new GetOpportunitiesResponse
            {
                Opportunities = opportunities
            };

            return Ok(response);
        }

        [HttpPost("get-opportunities-by-ids")]
        [SwaggerOperation(
            Summary = "Gets multplie opportunities by ids.",
            OperationId = "get-opportunities-by-ids",
            Tags = new[] { "Opportunities" }
        )]
        [SwaggerResponse(200, "Opportunities for all of the given ids.", typeof(GetOpportunitiesByIdsResponse))]
        [SwaggerResponse(206, "Opportunities for some of the given ids.", typeof(GetOpportunitiesByIdsResponse))]
        public ActionResult<GetOpportunitiesByIdsResponse> GetOpportunitiesByIds([FromBody] GetOpportunitiesByIdsRequest request)
        {
            var opportunities = _opportunityFacade.GetOpportunitiesByIds(request.OpportunityIds);

            var foundIds = opportunities.Select(opportunity => opportunity.Id.Value).ToList();
            var notFound = request.OpportunityIds.Where(id => !foundIds.Contains(id)).ToList();

            var response = new GetOpportunitiesByIdsResponse();
            response.Opportunities = opportunities;

            if (notFound.Any())
            {
                response.NotFound = notFound;
                return PartialSuccess(response);
            }

            return Ok(response);
        }

        private ActionResult<T> PartialSuccess<T>(T content)
        {
            var response = Ok(content);
            response.StatusCode = StatusCodes.Status206PartialContent;
            return response;
        }
    }
}