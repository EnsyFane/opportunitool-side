using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opportunitool.Data;
using Opportunitool.Dtos;
using Opportunitool.Infrastructure.Mapper;
using Opportunitool.Models;
using System.Collections.Generic;

namespace Opportunitool.Controllers
{
    [Route("opportunitool")]
    [ApiController]
    public class OpportunitiesController : ControllerBase
    {
        private readonly IOpportunityRepo _repository;
        private readonly IMappingCoordinator _mapper;

        public OpportunitiesController(IOpportunityRepo repository, IMappingCoordinator mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("opportunities")]
        public ActionResult<IEnumerable<OpportunityReadDto>> GetAllOpportunities()
        {
            var opportunities = _repository.GetAllOpportunities();
            return Ok(_mapper.Map<Opportunity, OpportunityReadDto>(opportunities));
        }

        [HttpGet("opportunities/{id}")]
        public ActionResult<OpportunityReadDto> GetOpportunityById(int id)
        {
            var opportunity = _repository.GetOpportunityById(id);
            if (opportunity != null)
            {
                return Ok(_mapper.Map<Opportunity, OpportunityReadDto>(opportunity));
            }

            return NotFound();
        }
    }
}