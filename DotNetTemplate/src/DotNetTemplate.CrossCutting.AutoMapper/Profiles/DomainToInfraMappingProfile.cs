using AutoMapper;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.Model.Entities;

namespace DotNetTemplate.CrossCutting.AutoMapper.Profiles {
    public class DomainToInfraMappingProfile : Profile {
        public DomainToInfraMappingProfile() {

            CreateMap<Team, TeamEntity>().ReverseMap();

        }
    }
}
