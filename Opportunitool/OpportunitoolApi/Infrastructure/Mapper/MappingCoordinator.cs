﻿using AutoMapper;
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