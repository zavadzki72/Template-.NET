using System;

namespace DotNetTemplate.Domain.Model.ViewModels.Team {
    public class TeamResponse {

        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public string Name { get; private set; }
        public string Initials { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string NickName { get; private set; }
        public string LogoImage { get; private set; }

    }
}
