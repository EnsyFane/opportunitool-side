using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpportunitoolApi.AppServices.Opportunities;
using OpportunitoolApi.AppServices.Opportunities.Model;
using OpportunitoolApi.Controllers.Models.Opportunities;
using OpportunitoolApi.Errors;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers
{
    [ApiController]
    [Route("opportunitool/opportunities")]
    public class OpportunityController : ControllerBase
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
            Summary = "Gets multiple opportunities by ids.",
            OperationId = "get-opportunities-by-ids",
            Tags = new[] { "Opportunities" }
        )]
        [SwaggerResponse(200, "Opportunities for all of the given ids.", typeof(GetOpportunitiesByIdsResponse))]
        [SwaggerResponse(206, "Opportunities for some of the given ids.", typeof(GetOpportunitiesByIdsResponse))]
        [SwaggerResponse(400, "Bad Request")]
        public ActionResult<GetOpportunitiesByIdsResponse> GetOpportunitiesByIds([FromBody] GetOpportunitiesByIdsRequest request)
        {
            var opportunities = _opportunityFacade.GetOpportunitiesByIds(request.OpportunityIds);

            var foundIds = opportunities.Select(opportunity => opportunity.Id.Value).ToList();
            var notFound = request.OpportunityIds.Where(id => !foundIds.Contains(id)).ToList();

            var response = new GetOpportunitiesByIdsResponse
            {
                Opportunities = opportunities
            };

            if (notFound.Any())
            {
                response.NotFound = notFound;
                return PartialSuccess(response);
            }

            return Ok(response);
        }

        [HttpPost("create-opportunities")]
        [SwaggerOperation(
            Summary = "Creates multiple opportunities.",
            OperationId = "create-opportunities",
            Tags = new[] { "Opportunities" }
        )]
        [SwaggerResponse(200, "The created opportunities.", typeof(CreateOpportunitiesResponse))]
        [SwaggerResponse(206, "The created opportunities and a list of errors for the opportunities that weren't created.", typeof(CreateOpportunitiesResponse))]
        [SwaggerResponse(400, "Bad Request")]
        public ActionResult<CreateOpportunitiesResponse> CreateOppotunities([FromBody] CreateOpportunitiesRequest request)
        {
            // TODO: Add request validation.
            var result = _opportunityFacade.CreateOpportunities(request.Opportunities);

            var response = new CreateOpportunitiesResponse
            {
                Opportunities = result.CreatedOpportunities
            };

            if (result.NotCreatedOpportunities.Any())
            {
                var notCreated = new List<KeyValuePair<OpportunityCreate, Error>>();
                foreach (var error in result.NotCreatedOpportunities)
                {
                    // TODO: Display the actual error.
                    notCreated.Add(new KeyValuePair<OpportunityCreate, Error>(error, new Error
                    {
                        ErrorCode = ErrorCodes.UnknownError,
                        ErrorMessage = "Unknown error."
                    }));
                }
                response.Errors = notCreated;

                return PartialSuccess(response);
            }

            return Ok(response);
        }

        [HttpPut("update-opportunities")]
        [SwaggerOperation(
            Summary = "Updates multiple opportunities.",
            OperationId = "update-opportunities",
            Tags = new[] { "Opportunities" }
        )]
        [SwaggerResponse(200, "The updated opportunities.", typeof(UpdateOpportunitiesResponse))]
        [SwaggerResponse(206, "The updated opportunities and a list of errors for the opportunities that weren't updated.", typeof(UpdateOpportunitiesResponse))]
        [SwaggerResponse(400, "Bad Request")]
        public ActionResult<UpdateOpportunitiesResponse> UpdateOpportunities([FromBody] UpdateOpportunitiesRequest request)
        {
            // TODO: Add request validation.
            var result = _opportunityFacade.UpdateOpportunities(request.Opportunities);

            var response = new UpdateOpportunitiesResponse
            {
                Opportunities = result.UpdatedOpportunities
            };

            if (result.NotUpdatedOpportunities.Any() || result.NotFoundOpportunities.Any())
            {
                var notUpdated = new List<KeyValuePair<OpportunityUpdate, Error>>();
                foreach (var error in result.NotUpdatedOpportunities)
                {
                    // TODO: Display the actual error.
                    notUpdated.Add(new KeyValuePair<OpportunityUpdate, Error>(error, new Error
                    {
                        ErrorCode = ErrorCodes.UnknownError,
                        ErrorMessage = "Unknown error."
                    }));
                }

                foreach (var notFound in result.NotFoundOpportunities)
                {
                    notUpdated.Add(new KeyValuePair<OpportunityUpdate, Error>(notFound, new Error
                    {
                        ErrorCode = ErrorCodes.OpportunityNotFoundError,
                        ErrorMessage = "No opportunity with the given identifier was found."
                    }));
                }
                response.Errors = notUpdated;

                return PartialSuccess(response);
            }

            return Ok(response);
        }

        [HttpDelete("delete-opportunities")]
        [SwaggerOperation(
            Summary = "Deletes multiple opportunities.",
            OperationId = "delete-opportunities",
            Tags = new[] { "Opportunities" }
        )]
        [SwaggerResponse(200, "The deleted opportunities ids.", typeof(DeleteOpportunitiesResponse))]
        [SwaggerResponse(206, "The deleted opportunities ids and a list of errors for the opportunities that weren't deleted.", typeof(DeleteOpportunitiesResponse))]
        public ActionResult<DeleteOpportunitiesResponse> DeleteOpportunities([FromBody] DeleteOpportunitiesRequest request)
        {
            var result = _opportunityFacade.DeleteOpportunities(request.OpportunityIds);

            var response = new DeleteOpportunitiesResponse
            {
                DeletedOpportunityIds = result.DeletedOpportunities
            };

            if (result.NotFoundOpportunities.Any())
            {
                var notUpdated = new List<KeyValuePair<long, Error>>();
                foreach (var notFound in result.NotFoundOpportunities)
                {
                    notUpdated.Add(new KeyValuePair<long, Error>(notFound, new Error
                    {
                        ErrorCode = ErrorCodes.OpportunityNotFoundError,
                        ErrorMessage = "No opportunity with the given identifier was found."
                    }));
                }
                response.Errors = notUpdated;

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