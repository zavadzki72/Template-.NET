using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Model;
using Microsoft.Extensions.Logging;

namespace DotNetTemplate.Domain.Core.Handlers {
    public abstract class CommandHandler {

        private readonly IMediatorHandler _bus;
        private readonly ILogger _logger;

        public CommandHandler(IMediatorHandler bus, ILogger<CommandHandler> logger) {
            _bus = bus;
            _logger = logger;
        }

        protected void NotifyValidationErrors(Command message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification("COMMAND_INVALIDO", $"{message.MessageType} : {error.ErrorMessage}"));
                _logger.LogError($"NotifyValidationErrors - FluentError - {error.ErrorMessage}");
            }
        }

        protected void NotifyValidationErrors<TResponse>(Command<TResponse> message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification("COMMAND_INVALIDO", $"{message.MessageType} : {error.ErrorMessage}"));
                _logger.LogError($"NotifyValidationErrors - FluentError - {error.ErrorMessage}");
            }
        }

    }
}
