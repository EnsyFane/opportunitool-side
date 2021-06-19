using AutoMapper;
using OpportunitoolApi.AppServices.Opportunities.Model;
using OpportunitoolApi.Core.Models;
using System.Collections.Generic;

namespace OpportunitoolApi.Infrastructure.Mapper
{
    /// <summary>
    /// Specific implementation of <see cref="IMappingCoordinator"/>.
    /// </summary>
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
                cfg.CreateMap<OpportunityCreate, Opportunity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<OpportunityUpdate, Opportunity>();
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

        /// <inheritdoc />
        public TDest Map<TSource, TDest>(TSource source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }
    }
}