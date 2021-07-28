using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Model;
using MediatR;
using System.Threading.Tasks;

namespace DotNetTemplate.CrossCutting.Bus {
    public sealed class InMemoryBus : IMediatorHandler {

        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator) {
            _mediator = mediator;
        }

        public async Task<TResponse> SendCommand<T, TResponse>(T command) where T : Command<TResponse> {
            return await _mediator.Send<TResponse>(command);
        }

        public async Task SendCommand<TRequest>(TRequest command) where TRequest : Command {
            await _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event {
            return _mediator.Publish(@event);
        }
    }
}
