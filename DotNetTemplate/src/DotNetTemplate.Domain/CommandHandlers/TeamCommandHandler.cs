using DotNetTemplate.Domain.Commands.Team;
using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Core.Handlers;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Model;
using log4net;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTemplate.Domain.CommandHandlers {

    public class TeamCommandHandler : CommandHandler, IRequestHandler<RegisterTeamCommand, Team> {

        private readonly ITeamRepository _teamRepository;
        private readonly IMediatorHandler _bus;
        private readonly ILog _log;

        public TeamCommandHandler(ITeamRepository teamRepository, IMediatorHandler bus, ILog log) : base(bus, log) {
            _teamRepository = teamRepository;
            _bus = bus;
            _log = log;
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
                _log.Error("RegisterTeamCommandHandler - CommitError - Ocorreu um erro ao inserir suas alterações");
                return null;
            }

            return team;
        }
    }
}
