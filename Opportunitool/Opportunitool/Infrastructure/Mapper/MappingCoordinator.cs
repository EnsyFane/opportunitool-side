using AutoMapper;
using Opportunitool.Dtos;
using Opportunitool.Models;
using System.Collections.Generic;

namespace Opportunitool.Infrastructure.Mapper
{
    public class MappingCoordinator : IMappingCoordinator
    {
        private readonly IMapper _mapper;
        protected IMapper Mapper => _mapper;

        public MappingCoordinator()
        {
            var config = InitializeMapping();
            _mapper = config.CreateMapper();
        }

        private MapperConfiguration InitializeMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Opportunity, OpportunityReadDto>();
                cfg.CreateMap<OpportunityCreateDto, Opportunity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<OpportunityUpdateDto, Opportunity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<Opportunity, OpportunityUpdateDto>();
            });
        }

        /// <inheritdoc />
        public TDest Map<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TSource, TDest>(source);
        }

        /// <inheritdoc />
        public IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source);
        }

        public TDest Map<TSource, TDest>(TSource source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }
    }
}