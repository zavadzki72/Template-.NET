using AutoMapper;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.Commands.Team;
using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Core.Handlers;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Interfaces.Services;
using DotNetTemplate.Domain.Model;
using DotNetTemplate.Domain.Model.ViewModels.Team;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.ApplicationService {

    public class TeamApplicationService : ITeamApplicationService {

        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public TeamApplicationService(ITeamRepository teamRepository, IMapper mapper, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _bus = bus;

            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<ServiceResult<List<TeamResponse>>> GetAll() {

            var teams = await _teamRepository.GetAll();

            if(teams == null) {
                return ServiceResult<List<TeamResponse>>.NotFound(AddNotificationToReturn("NOT_FOUND", "Nao achamos nenhum time no sistema"));
            }

            var teamsMapped = _mapper.Map<List<TeamResponse>>(teams);

            return ServiceResult<List<TeamResponse>>.Ok(teamsMapped);
        }

        public async Task<ServiceResult<TeamResponse>> GetById(Guid id) {

            var team = await _teamRepository.GetById(id);

            if(team == null) {
                return ServiceResult<TeamResponse>.NotFound(AddNotificationToReturn("NOT_FOUND", $"Nao achamos o time com o ID: {id} no sistema"));
            }

            var teamMapped = _mapper.Map<TeamResponse>(team);

            return ServiceResult<TeamResponse>.Ok(teamMapped);
        }

        public async Task<ServiceResult<TeamResponse>> Register(RegisterTeamViewModel registerTeamViewModel) {
            
            var command = _mapper.Map<RegisterTeamCommand>(registerTeamViewModel);
            var team = await _bus.SendCommand<RegisterTeamCommand, Team>(command);

            if(team == null)
                return ServiceResult<TeamResponse>.Error(AddNotificationToReturn("Error", $"Ocorreu um erro ao inserir o time no sistema"));

            var teamMapped = _mapper.Map<TeamResponse>(team);

            return ServiceResult<TeamResponse>.Ok(teamMapped);
        }

        public async Task<ServiceResult<TeamResponse>> Update(UpdateTeamViewModel updateTeamViewModel) {

            var command = _mapper.Map<UpdateTeamCommand>(updateTeamViewModel);
            var team = await _bus.SendCommand<UpdateTeamCommand, Team>(command);

            if(team == null)
                return ServiceResult<TeamResponse>.Error(AddNotificationToReturn("Error", $"Ocorreu um erro ao atualizar o time no sistema"));

            var teamMapped = _mapper.Map<TeamResponse>(team);

            return ServiceResult<TeamResponse>.Ok(teamMapped);
        }

        private DomainNotification[] AddNotificationToReturn(string key, string error) {

            var notifications = _notifications.GetNotifications();

            notifications.Add(new DomainNotification(key, error));

            return notifications.ToArray();
        }

    }
}
