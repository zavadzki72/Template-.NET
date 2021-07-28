using AutoMapper;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Interfaces.Services;
using DotNetTemplate.Domain.Model;
using DotNetTemplate.Domain.Model.ViewModels.Team;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.ApplicationService {
    public class TeamApplicationService : ITeamApplicationService {

        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamApplicationService(ITeamRepository teamRepository, IMapper mapper) {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<TeamResponse>>> GetAll() {

            var teams = await _teamRepository.GetAll();

            if(teams == null) {
                return ServiceResult<List<TeamResponse>>.NotFound(new DomainNotification("NOT_FOUND", "Nao achamos nenhum time no sistema"));
            }

            var teamsMapped = _mapper.Map<List<TeamResponse>>(teams);

            return ServiceResult<List<TeamResponse>>.Ok(teamsMapped);
        }
    }
}
