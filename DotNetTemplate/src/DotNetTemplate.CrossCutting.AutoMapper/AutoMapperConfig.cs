using AutoMapper;
using DotNetTemplate.CrossCutting.AutoMapper.Profiles;

namespace DotNetTemplate.CrossCutting.AutoMapper {
    public static class AutoMapperConfig {

        public static MapperConfiguration RegisterMappings() {
            return new MapperConfiguration((config) => {
                config.AddProfile(new PresentationToApplicationMappingProfile());
                config.AddProfile(new ApplicationToDomainMappingProfile());
                config.AddProfile(new DomainToInfraMappingProfile());
            });
        }

    }
}
