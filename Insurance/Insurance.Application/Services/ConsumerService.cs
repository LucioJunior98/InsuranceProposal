using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Application;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Insurance.Application.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IProposalHiringService _proposalHiringService;

        public ConsumerService(IProposalHiringService proposalHiring)
        {
            _proposalHiringService = proposalHiring;
        }

        public async Task<bool> ConsumeMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            bool haveMessage = false;

            try
            {

                await channel.QueueDeclareAsync(queue: "ProposalHiringQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.ReceivedAsync += async (model, ea) =>
                {
                    haveMessage = true;

                    var body = ea.Body.ToArray();
                    var message = System.Text.Encoding.UTF8.GetString(body);

                    ProposalHiring proposalHiring = System.Text.Json.JsonSerializer.Deserialize<ProposalHiring>(message);

                    if (proposalHiring != null)
                        await _proposalHiringService.UpdateProposalHiring(proposalHiring.Id, ProposalHiringStatus.Completed, 2);
                    else
                        haveMessage = false;

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                };

                await channel.BasicConsumeAsync(queue: "ProposalHiringQueue", autoAck: false, consumer: consumer);
            }
            catch(Exception ex)
            {
                haveMessage = false;
            }

            return haveMessage;
        }
    }
}
