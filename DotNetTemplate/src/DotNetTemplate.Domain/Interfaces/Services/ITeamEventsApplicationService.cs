using System;
using System.Threading.Tasks;

namespace DotNetTemplate.Domain.Interfaces.Services {
    public interface ITeamEventsApplicationService {

        Task TeamCreated(Guid id);

    }
}
