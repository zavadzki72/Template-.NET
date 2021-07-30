using DotNetTemplate.Domain.Model.Interfaces;
using DotNetTemplate.Domain.QueryModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.Domain.Interfaces.ElasticSearch {

    public interface ITeamQuery : IElasticSearchBaseQuery<Team, TeamQueryModel> {

        Task<Team> GetById(Guid id);
        Task<List<Team>> GetAll();

    }
}
