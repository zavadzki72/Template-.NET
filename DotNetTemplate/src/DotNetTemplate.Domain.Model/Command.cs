using FluentValidation.Results;
using MediatR;
using System;

namespace DotNetTemplate.Domain.Model {
    public abstract class Command<TResponse> : Message, IRequest<TResponse> {

        protected Command() {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();

    }

    public abstract class Command : Message {
        protected Command() {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
