using System;

namespace DotNetTemplate.Domain.Model.ViewModels.Team {
    public class UpdateTeamViewModel {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string NickName { get; set; }
        public string LogoImage { get; set; }

    }
}
