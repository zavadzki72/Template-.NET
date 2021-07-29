using DotNetTemplate.Domain.Commands.Team;
using FluentValidation;

namespace DotNetTemplate.Domain.CommandValidations.Team {

    public abstract class TeamValidator<T> : AbstractValidator<T> where T : TeamCommand {

        private const string RegexLink = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";

        #region Validation Messages
        private const string FieldRequired = "O campo não pode ser vazio";
        private const string MaxLength = "O campo ultrapassou o limite de caracteres";
        private const string InvalidLink = "Link está invalido";
        #endregion

        protected void ValidateId() {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage(FieldRequired);
        }

        protected void ValidateName() {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(FieldRequired);
        }

        protected void ValidateNickName() {
            RuleFor(c => c.NickName)
                .NotEmpty()
                .WithMessage(FieldRequired);
        }

        protected void ValidateInitials() {
            RuleFor(c => c.Initials)
                .NotEmpty()
                .WithMessage(FieldRequired)
                .MaximumLength(4)
                .WithMessage(MaxLength);
        }

        protected void ValidateCity() {
            RuleFor(c => c.City)
                .NotEmpty()
                .WithMessage(FieldRequired);
        }

        protected void ValidateState() {
            RuleFor(c => c.State)
                .NotEmpty()
                .WithMessage(FieldRequired);
        }

        protected void ValidateLogoImage() {
            RuleFor(c => c.LogoImage)
                .NotEmpty()
                .WithMessage(FieldRequired)
                .Matches(RegexLink)
                .WithMessage(InvalidLink);
        }
    }
}
