using DotNetTemplate.Domain.Commands.Team;

namespace DotNetTemplate.Domain.CommandValidations.Team {

    public class RegisterTeamCommandValidator :  TeamValidator<RegisterTeamCommand> {

        public RegisterTeamCommandValidator() {
            ValidateName();
            ValidateNickName();
            ValidateCity();
            ValidateState();
            ValidateInitials();
            ValidateLogoImage();
        }

    }
}
