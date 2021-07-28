using DotNetTemplate.Domain.Model.Enumerators;

namespace DotNetTemplate.Domain.Model {
    public class DomainNotification : Event {

        public DomainNotification(string key, string message) {
            Key = key;
            Message = message;
        }

        public string Key { get; private set; }
        public string Message { get; private set; }
    }
}
