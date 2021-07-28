using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Model;
using log4net;

namespace DotNetTemplate.Domain.Core.Handlers {
    public abstract class CommandHandler {

        private readonly IMediatorHandler _bus;
        private readonly ILog _log;

        public CommandHandler(IMediatorHandler bus, ILog log) {
            _bus = bus;
            _log = log;
        }

        protected void NotifyValidationErrors(Command message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification("COMMAND_INVALIDO", $"{message.MessageType} : {error.ErrorMessage}"));
                _log.Error($"NotifyValidationErrors - FluentError - {error.ErrorMessage}");
            }
        }

        protected void NotifyValidationErrors<TResponse>(Command<TResponse> message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification("COMMAND_INVALIDO", $"{message.MessageType} : {error.ErrorMessage}"));
                _log.Error($"NotifyValidationErrors - FluentError - {error.ErrorMessage}");
            }
        }

    }
}
