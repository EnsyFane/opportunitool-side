using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OpportunitoolApi.Controllers
{
    [Route("opportunitool")]
    [ApiController]
    public class RootEndpointController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Pings the server.",
            OperationId = "ping",
            Tags = new[] { "API Endpoints" }
        )]
        [SwaggerResponse(200, "The server is online. The list of operations and their version.")]
        public IActionResult RootEndpoint()
        {
            return Ok(GetV1());
        }

        [HttpGet("v1")]
        [SwaggerOperation(
            Summary = "Pings the server.",
            OperationId = "ping-v1",
            Tags = new[] { "API Endpoints" }
        )]
        [SwaggerResponse(200, "The server is online. The list of operations and their version.")]
        public IActionResult V1()
        {
            return Ok(GetV1Operations());
        }

        private static ApiVersion1 GetV1()
        {
            return new ApiVersion1()
            {
                V1 = GetV1Operations()
            };
        }

        private static V1Operations GetV1Operations()
        {
            return new V1Operations()
            {
                Operations = new OpportunityOperations()
                {
                    ReadOpportunities = new Operation() { Available = true, Version = 1 },
                    WriteOpportunities = new Operation() { Available = true, Version = 1 },
                    DeleteOppotrunities = new Operation() { Available = true, Version = 1 },
                    UpdateOppotrunities = new Operation() { Available = true, Version = 1 },
                }
            };
        }

        private class ApiVersion1
        {
            public V1Operations V1 { get; set; }
        }

        private class V1Operations
        {
            public OpportunityOperations Operations { get; set; }
        }

        private class OpportunityOperations
        {
            public Operation ReadOpportunities { get; set; }

            public Operation WriteOpportunities { get; set; }

            public Operation DeleteOppotrunities { get; set; }

            public Operation UpdateOppotrunities { get; set; }
        }

        private class Operation
        {
            public bool Available { get; set; }
            public int Version { get; set; }
        }
    }
}