using Interfaces;

namespace Services
{
    public class MessageService : IMessageService
    {
        private readonly IConnectionService _connection;

        public MessageService(IConnectionService connection)
        {
            _connection = connection;
        }

        public void SendMessage(string content)
        {
            _connection.OpenConnection();

            //.....

            _connection.CloseConnection();
        }
    }
}