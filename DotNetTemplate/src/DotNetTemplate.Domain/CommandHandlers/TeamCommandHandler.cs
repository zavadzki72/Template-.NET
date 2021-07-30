using DotNetTemplate.Domain.Commands.Team;
using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Core.Handlers;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MassTransit;
using DotNetTemplate.Domain.Events;

namespace DotNetTemplate.Domain.CommandHandlers {

    public class TeamCommandHandler : CommandHandler, 
        IRequestHandler<RegisterTeamCommand, Team>,
        IRequestHandler<UpdateTeamCommand, Team> {

        private readonly ITeamRepository _teamRepository;
        private readonly IMediatorHandler _bus;
        private readonly ILogger _logger;
        private readonly IBus _queueBus;

        public TeamCommandHandler(ITeamRepository teamRepository, IMediatorHandler bus, ILogger<TeamCommandHandler> logger, IBus queueBus) : base(bus, logger) {
            _teamRepository = teamRepository;
            _bus = bus;
            _logger = logger;
            _queueBus = queueBus;
        }

        public async Task<Team> Handle(RegisterTeamCommand request, CancellationToken cancellationToken) {

            if(!request.IsValid()) {
                NotifyValidationErrors(request);
                return null;
            }

            var team = new Team(request.Name, request.Initials, request.City, request.State, request.NickName, request.LogoImage);
            _teamRepository.Insert(team);

            var success = await _teamRepository.Commit();

            if(!success) {
                await _bus.RaiseEvent(new DomainNotification("COMMIT_ERROR", "Ocorreu um erro ao inserir suas alterações"));
                _logger.LogError("RegisterTeamCommandHandler - CommitError - Ocorreu um erro ao inserir suas alterações");
                return null;
            }

            await _queueBus.Publish(new TeamCreatedEvent(team.Id), cancellationToken);

            return team;
        }

        public async Task<Team> Handle(UpdateTeamCommand request, CancellationToken cancellationToken) {

            if(!request.IsValid()) {
                NotifyValidationErrors(request);
                return null;
            }

            var actualTeam = await _teamRepository.GetById(request.Id);

            if(actualTeam == null) {
                await _bus.RaiseEvent(new DomainNotification("UPDATE_ERROR", $"O time com o ID: {request.Id} para a atualizacao nao existe"));
                _logger.LogError($"UpdateTeamCommandHandler - UpdateError - O time com o ID: {request.Id} para a atualizacao nao existe");
                return null;
            }

            var teamToUpdate = new Team(request.Name, request.Initials, request.City, request.State, request.NickName, request.LogoImage);
            actualTeam.Update(teamToUpdate);

            await _teamRepository.Update(actualTeam);

            var success = await _teamRepository.Commit();

            if(!success) {
                await _bus.RaiseEvent(new DomainNotification("COMMIT_ERROR", "Ocorreu um erro ao atualizar suas alterações"));
                _logger.LogError("UpdateTeamCommandHandler - CommitError - Ocorreu um erro ao atualizar suas alterações");
                return null;
            }

            return actualTeam;

        }
    }
}
