using MediatR;

namespace DotNetTemplate.Domain.Core.Models {

    public abstract class Message : IRequest {

        public string MessageType { get; protected set; }

        protected Message() {
            MessageType = GetType().Name;
        }

    }
}
