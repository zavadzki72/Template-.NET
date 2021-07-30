using DotNetTemplate.Domain.Interfaces.ElasticSearch;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace DotNetTemplate.ApplicationService {
    public class TeamEventsApplicationService : ITeamEventsApplicationService {

        private readonly ITeamQuery _teamQuery;
        private readonly ITeamRepository _teamRepository;

        public TeamEventsApplicationService(ITeamQuery teamQuery, ITeamRepository teamRepository) {
            _teamQuery = teamQuery;
            _teamRepository = teamRepository;
        }

        public async Task TeamCreated(Guid id) {
            var team = await _teamRepository.GetById(id);
            await _teamQuery.IndexAsync(team);
        }
    }
}
