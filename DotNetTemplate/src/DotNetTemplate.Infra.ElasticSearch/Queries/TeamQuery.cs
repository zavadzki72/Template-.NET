using AutoMapper;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.Interfaces.ElasticSearch;
using DotNetTemplate.Domain.QueryModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTemplate.Infra.ElasticSearch.Queries {

    public class TeamQuery : BaseQuery<Team, TeamQueryModel>, ITeamQuery {

        public TeamQuery(IMapper mapper, IConfiguration configuration) : base(mapper, configuration) { }

        public async Task<Team> GetById(Guid id) {

            var resultLazy = new LazyAsync<TeamQueryModel>(async () => {

                var qResult = await GetClient().SearchAsync<TeamQueryModel>(
                    x => x.Query(m => m.MatchPhrase(mc => mc.Field("id").Query(id.ToString())))
                );

                if(!qResult.IsValid || qResult.Documents == null || !qResult.Documents.Any())
                    return null;

                var teamQueryModel = qResult.Documents.FirstOrDefault();

                return teamQueryModel;
            });

            var responseMapped = _mapper.Map<Team>(await resultLazy.Value);

            return responseMapped;
        }

        public async Task<List<Team>> GetAll() {

            var resultLazy = new LazyAsync<List<TeamQueryModel>>(async () => {

                var qResult = await GetClient().SearchAsync<TeamQueryModel>();

                if(!qResult.IsValid || qResult.Documents == null || !qResult.Documents.Any())
                    return null;

                var teamQueryModel = qResult.Documents.ToList();

                return teamQueryModel;
            });

            var responseMapped = _mapper.Map<List<Team>>(await resultLazy.Value);

            return responseMapped;
        }

    }
}
