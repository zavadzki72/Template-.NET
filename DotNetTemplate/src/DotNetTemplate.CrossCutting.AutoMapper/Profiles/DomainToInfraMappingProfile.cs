using AutoMapper;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.Model.Entities;
using DotNetTemplate.Domain.QueryModels;

namespace DotNetTemplate.CrossCutting.AutoMapper.Profiles {
    public class DomainToInfraMappingProfile : Profile {
        public DomainToInfraMappingProfile() {

            CreateMap<Team, TeamEntity>().ReverseMap();
            CreateMap<Team, TeamQueryModel>().ReverseMap();
        }
    }
}
