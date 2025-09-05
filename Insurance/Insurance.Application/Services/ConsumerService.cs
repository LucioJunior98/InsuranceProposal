using System.Text.Json;
using Confluent.Kafka;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Application;

namespace Insurance.Application.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IProposalHiringService _proposalHiringService;

        private ConsumerConfig config => new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "ProposalHiring-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        public ConsumerService(IProposalHiringService proposalHiring)
        {
            _proposalHiringService = proposalHiring;
        }

        public void ConsumeMessage()
        {
            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("ProposalHiring-topic");

            try
            {

                while (true)
                {
                    var consumeResult = consumer.Consume();
                    if (consumeResult.Message != null)
                    {
                        ProposalHiring proposalHiring = JsonSerializer.Deserialize<ProposalHiring>(consumeResult.Message.Value) ?? new ProposalHiring();

                        _proposalHiringService.CreateProposalHiring(proposalHiring);

                        break;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
