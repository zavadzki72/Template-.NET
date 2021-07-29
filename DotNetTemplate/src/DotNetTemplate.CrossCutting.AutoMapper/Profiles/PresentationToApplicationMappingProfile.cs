using AutoMapper;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.Model.ViewModels.Team;

namespace DotNetTemplate.CrossCutting.AutoMapper.Profiles {
    public class PresentationToApplicationMappingProfile : Profile {
        public PresentationToApplicationMappingProfile() {

            CreateMap<Team, TeamResponse>().ReverseMap();

        }
    }
}
