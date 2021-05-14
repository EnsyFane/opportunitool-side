﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("opportunities/{id}", Name = "GetOpportunityById")]
        public ActionResult<OpportunityReadDto> GetOpportunityById(int id)
        {
            var opportunity = _repository.GetOpportunityById(id);
            if (opportunity != null)
            {
                return Ok(_mapper.Map<Opportunity, OpportunityReadDto>(opportunity));
            }

            return NotFound();
        }

        [HttpPost("opportunities")]
        public ActionResult<OpportunityReadDto> CreateOpportunity(OpportunityCreateDto opportunityCreateDto)
        {
            var opportunity = _mapper.Map<OpportunityCreateDto, Opportunity>(opportunityCreateDto);
            _repository.CreateOpportunity(opportunity);
            _repository.SaveChanges();

            var opportunityReadDto = _mapper.Map<Opportunity, OpportunityReadDto>(opportunity);

            return CreatedAtRoute(nameof(GetOpportunityById), new { opportunityReadDto.Id }, opportunityReadDto);
        }

        [HttpPut("opportunities/{id}")]
        public ActionResult UpdateOpportunity(int id, OpportunityUpdateDto opportunityUpdateDto)
        {
            var opportunityFromRepo = _repository.GetOpportunityById(id);

            if (opportunityFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(opportunityUpdateDto, opportunityFromRepo);

            _repository.UpdateOpportunity(opportunityFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("opportunities/{id}")]
        public ActionResult PatchOpportunity(int id, JsonPatchDocument<OpportunityUpdateDto> patchDocument)
        {
            var opportunityFromRepo = _repository.GetOpportunityById(id);

            if (opportunityFromRepo == null)
            {
                return NotFound();
            }

            var opportunityToPatch = _mapper.Map<Opportunity, OpportunityUpdateDto>(opportunityFromRepo);
            patchDocument.ApplyTo(opportunityToPatch, ModelState);
            if (!TryValidateModel(opportunityToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(opportunityToPatch, opportunityFromRepo);

            _repository.UpdateOpportunity(opportunityFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("opportunities/{id}")]
        public ActionResult DeleteOpportunity(int id)
        {
            var opportunityFromRepo = _repository.GetOpportunityById(id);

            if (opportunityFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteOpportunity(opportunityFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}