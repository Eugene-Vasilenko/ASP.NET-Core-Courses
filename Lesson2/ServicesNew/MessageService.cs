using Interfaces;

namespace ServicesNew
{
    public class MessageService : IMessageService
    {
        private readonly ICounter _counter;

        public MessageService(ICounter counter)
        {
            _counter = counter;
        }

        public void SendMessage(string content)
        {
            _counter.IncrementValue();
        }
    }
}