using AutoMapper;
using DotNetTemplate.Domain.Commands.Team;
using DotNetTemplate.Domain.Model.ViewModels.Team;

namespace DotNetTemplate.CrossCutting.AutoMapper.Profiles {
    public class ApplicationToDomainMappingProfile : Profile {
        public ApplicationToDomainMappingProfile() {

            CreateMap<RegisterTeamViewModel, RegisterTeamCommand>().IgnoreAllUnmapped().ReverseMap();
            CreateMap<UpdateTeamViewModel, UpdateTeamCommand>().IgnoreAllUnmapped().ReverseMap();

        }
    }
}
