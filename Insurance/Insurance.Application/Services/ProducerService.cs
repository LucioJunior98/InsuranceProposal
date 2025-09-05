using Insurance.Domain.Interfaces.Application;
using RabbitMQ.Client;

namespace Insurance.Application.Services
{
    public class ProducerService : IProducerService
    {
        public async Task<bool> GenerateMessage(string message)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                await using var connection = await factory.CreateConnectionAsync();
                await using var channel = await connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(queue: "ProposalHiringQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                ReadOnlyMemory<byte> msg = System.Text.Encoding.UTF8.GetBytes(message); 

                await channel.BasicPublishAsync(exchange: "",
                                         routingKey: "ProposalHiringQueue",
                                         mandatory: true,
                                         basicProperties: new BasicProperties(),
                                         body: msg);



                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
