using Confluent.Kafka;
using Insurance.Domain.Interfaces.Application;

namespace Insurance.Application.Services
{
    public class ProducerService : IProducerService
    {
        private ProducerConfig config => new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        public string GenerateMessage(string message)
        {
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            string resultMessage = string.Empty;    

            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(message))
                        break;

                    var result = producer.ProduceAsync("ProposalHiring-topic", new Message<Null, string> { Value = message });

                    resultMessage = result.Result.Value;
                }
                catch (Exception ex)
                {
                    resultMessage = ex.Message;
                    break;
                }
            }

            return resultMessage;
        }
    }
}
