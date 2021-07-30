using System;

namespace DotNetTemplate.Domain.Events {
    public class TeamCreatedEvent {

        public TeamCreatedEvent(Guid idTeam) {
            IdTeam = idTeam;
        }

        public Guid IdTeam { get; private set; }
    }
}
