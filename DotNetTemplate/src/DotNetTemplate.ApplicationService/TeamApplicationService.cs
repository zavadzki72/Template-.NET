using AutoMapper;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.Commands.Team;
using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Interfaces.Services;
using DotNetTemplate.Domain.Model;
using DotNetTemplate.Domain.Model.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.ApplicationService {

    public class TeamApplicationService : ITeamApplicationService {

        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public TeamApplicationService(ITeamRepository teamRepository, IMapper mapper, IMediatorHandler bus) {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<ServiceResult<List<TeamResponse>>> GetAll() {

            var teams = await _teamRepository.GetAll();

            if(teams == null) {
                return ServiceResult<List<TeamResponse>>.NotFound(new DomainNotification("NOT_FOUND", "Nao achamos nenhum time no sistema"));
            }

            var teamsMapped = _mapper.Map<List<TeamResponse>>(teams);

            return ServiceResult<List<TeamResponse>>.Ok(teamsMapped);
        }

        public async Task<ServiceResult<TeamResponse>> GetById(Guid id) {

            var team = await _teamRepository.GetById(id);

            if(team == null) {
                return ServiceResult<TeamResponse>.NotFound(new DomainNotification("NOT_FOUND", $"Nao achamos o time com o ID: {id} no sistema"));
            }

            var teamMapped = _mapper.Map<TeamResponse>(team);

            return ServiceResult<TeamResponse>.Ok(teamMapped);
        }

        public async Task<ServiceResult<TeamResponse>> Register(RegisterTeamViewModel registerTeamViewModel) {
            
            var command = _mapper.Map<RegisterTeamCommand>(registerTeamViewModel);
            var team = await _bus.SendCommand<RegisterTeamCommand, Team>(command);

            if(team == null)
                return ServiceResult<TeamResponse>.Error(new DomainNotification("Error", $"Ocorreu um erro ao inserir o time no sistema"));

            var teamMapped = _mapper.Map<TeamResponse>(team);

            return ServiceResult<TeamResponse>.Ok(teamMapped);
        }

        public async Task<ServiceResult<TeamResponse>> Update(UpdateTeamViewModel updateTeamViewModel) {

            var command = _mapper.Map<UpdateTeamCommand>(updateTeamViewModel);
            var team = await _bus.SendCommand<UpdateTeamCommand, Team>(command);

            if(team == null)
                return ServiceResult<TeamResponse>.Error(new DomainNotification("Error", $"Ocorreu um erro ao atualizar o time no sistema"));

            var teamMapped = _mapper.Map<TeamResponse>(team);

            return ServiceResult<TeamResponse>.Ok(teamMapped);
        }
    }
}
