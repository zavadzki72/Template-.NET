using AutoMapper;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Model.Entities;
using DotNetTemplate.Infra.PostgreSql.Context;
using DotNetTemplate.Infra.PostgreSql.Repositories.Base;

namespace DotNetTemplate.Infra.PostgreSql.Repositories {
    public class TeamRepository : BaseRepository<TeamEntity, Team>, ITeamRepository {

        public TeamRepository(IMapper mapper, ApplicationDbContext db) : base(mapper, db) { }

    }
}
