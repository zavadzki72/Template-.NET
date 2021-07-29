using DotNetTemplate.Domain.Model;
using System;

namespace DotNetTemplate.Domain.Commands.Team {

    public abstract class TeamCommand : Command<Domain.Team> {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string NickName { get; set; }
        public string LogoImage { get; set; }

    }
}
