using DotNetTemplate.Domain.CommandValidations.Team;
using System;

namespace DotNetTemplate.Domain.Commands.Team {

    public class UpdateTeamCommand : TeamCommand {

        private UpdateTeamCommand() { }

        public UpdateTeamCommand(Guid id, string name, string initials, string city, string state, string nickName, string logoImage) {
            Id = id;
            Name = name;
            Initials = initials;
            City = city;
            State = state;
            NickName = nickName;
            LogoImage = logoImage;
        }

        public override bool IsValid() {
            ValidationResult = new UpdateTeamCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
