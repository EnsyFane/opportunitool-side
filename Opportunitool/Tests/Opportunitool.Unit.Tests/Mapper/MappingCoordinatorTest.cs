using OpportunitoolApi.Infrastructure.Mapper;
using Xunit;

namespace Opportunitool.Unit.Tests.Mapper
{
    public class MappingCoordinatorTest
    {
        [Fact]
        public void InitializeMappings_ConfigurationIsValid()
        {
            var mappingCoordinator = new TestMappingCoordinator();
            mappingCoordinator.AssertConfigurationIsValid();
        }

        private class TestMappingCoordinator : MappingCoordinator
        {
            public void AssertConfigurationIsValid()
            {
                Mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
        }
    }
}