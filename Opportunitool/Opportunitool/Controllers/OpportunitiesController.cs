using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opportunitool.Data;
using Opportunitool.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace Opportunitool.Controllers
{
    [Route("opportunitool")]
    [ApiController]
    public class OpportunitiesController : ControllerBase
    {
        private readonly IOpportunityRepo _repository;
        private readonly IMapper _mapper;

        public OpportunitiesController(IOpportunityRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("opportunities")]
        public ActionResult<IEnumerable<OpportunityReadDto>> GetAllOpportunities()
        {
            var opportunities = _repository.GetAllOpportunities();
            return Ok(_mapper.Map<OpportunityReadDto>(opportunities));
        }

        [HttpGet("opportunities/{id}")]
        public ActionResult<OpportunityReadDto> GetOpportunityById(int id)
        {
            var opportunity = _repository.GetOpportunityById(id);
            if (opportunity != null)
            {
                return Ok(_mapper.Map<OpportunityReadDto>(opportunity));
            }

            return NotFound();
        }
    }
}