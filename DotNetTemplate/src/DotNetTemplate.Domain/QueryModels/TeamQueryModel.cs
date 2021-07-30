using DotNetTemplate.Domain.Model.Interfaces;
using Nest;
using System;

namespace DotNetTemplate.Domain.QueryModels {

    [ElasticsearchType(RelationName = "team")]
    public class TeamQueryModel : IElasticSearchQueryModel {

        public string GetIndexName {
            get {
                return "idx-team";
            }
        }

        public TeamQueryModel() { }

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [Keyword]
        public string Name { get; set; }

        [Keyword]
        public string Initials { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }

        [Keyword]
        public string NickName { get; set; }

        public string LogoImage { get; set; }

    }
}
