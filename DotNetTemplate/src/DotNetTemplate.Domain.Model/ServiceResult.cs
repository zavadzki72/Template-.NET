using DotNetTemplate.Domain.Model.Enumerators;
using System.Collections.Generic;

namespace DotNetTemplate.Domain.Model {

    public class ServiceResult<T> {

        public T Model { get; private set; }
        public bool Success { get; private set; }
        public ServiceResultStatus Status { get; private set; }
        public List<DomainNotification> Notifications { get; private set; }

        public static ServiceResult<T> Ok(T model) {
            return new ServiceResult<T> {
                Model = model,
                Status = ServiceResultStatus.OK,
                Success = true,
                Notifications = new List<DomainNotification>()
            };
        }

        public static ServiceResult<T> Error(params DomainNotification[] notifications) {
            var result = new ServiceResult<T> {
                Model = default,
                Status = ServiceResultStatus.ERROR,
                Success = false,
                Notifications = new List<DomainNotification>()
            };

            result.Notifications.AddRange(notifications);
            return result;
        }

        public static ServiceResult<T> NotFound(params DomainNotification[] notifications) {
            var result = new ServiceResult<T> {
                Model = default,
                Status = ServiceResultStatus.NOT_FOUND,
                Success = false,
                Notifications = new List<DomainNotification>()
            };

            result.Notifications.AddRange(notifications);
            return result;
        }

        public static ServiceResult<T> Personalized(bool success, T model, ServiceResultStatus status, params DomainNotification[] notifications) {
            var result = new ServiceResult<T> {
                Model = model,
                Status = status,
                Success = success,
                Notifications = new List<DomainNotification>()
            };

            if(notifications != null && notifications.Length > 0)
                result.Notifications.AddRange(notifications);
            
            return result;
        }
    }
}
