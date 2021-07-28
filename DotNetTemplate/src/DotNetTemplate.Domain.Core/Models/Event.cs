using MediatR;
using System;

namespace DotNetTemplate.Domain.Core.Models {

    public abstract class Event : Message, INotification {

        public DateTime Timestamp { get; }

        protected Event() {
            Timestamp = DateTime.Now;
        }
    }
}
