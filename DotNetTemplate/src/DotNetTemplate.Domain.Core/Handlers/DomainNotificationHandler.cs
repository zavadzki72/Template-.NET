using DotNetTemplate.Domain.Model;
using DotNetTemplate.Domain.Model.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTemplate.Domain.Core.Handlers {

    public class DomainNotificationHandler : IDisposable, INotificationHandler<DomainNotification> {

        private List<DomainNotification> _notifications;

        public DomainNotificationHandler() {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken) {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public void Dispose() {
            _notifications = new List<DomainNotification>();
        }

    }
}
