using DotNetTemplate.Domain.Commands.Team;

namespace DotNetTemplate.Domain.CommandValidations.Team {
    public class UpdateTeamCommandValidator : TeamValidator<UpdateTeamCommand> {

        public UpdateTeamCommandValidator() {
            ValidateId();
            ValidateName();
            ValidateNickName();
            ValidateCity();
            ValidateState();
            ValidateInitials();
            ValidateLogoImage();
        }

    }
}
