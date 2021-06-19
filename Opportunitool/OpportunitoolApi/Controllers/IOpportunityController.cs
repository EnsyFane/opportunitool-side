using Microsoft.AspNetCore.Mvc;
using OpportunitoolApi.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitoolApi.Controllers
{
    public interface IOpportunityController
    {
        ActionResult<GetOpportunityResponse> GetOpportunityById(long opportunityId);
    }
}