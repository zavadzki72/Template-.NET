using DotNetTemplate.Domain.CommandValidations.Team;

namespace DotNetTemplate.Domain.Commands.Team {

    public class RegisterTeamCommand : TeamCommand {

        private RegisterTeamCommand() { }

        public RegisterTeamCommand(string name, string initials, string city, string state, string nickName, string logoImage) {
            Name = name;
            Initials = initials;
            City = city;
            State = state;
            NickName = nickName;
            LogoImage = logoImage;
        }

        public override bool IsValid() {
            ValidationResult = new RegisterTeamCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
