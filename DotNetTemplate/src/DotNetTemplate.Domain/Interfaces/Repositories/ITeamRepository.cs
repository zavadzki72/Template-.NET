using DotNetTemplate.Domain.Model.Entities;
using DotNetTemplate.Domain.Model.Interfaces;

namespace DotNetTemplate.Domain.Interfaces.Repositories {
    public interface ITeamRepository : IBaseRepository<TeamEntity, Team> { }
}
