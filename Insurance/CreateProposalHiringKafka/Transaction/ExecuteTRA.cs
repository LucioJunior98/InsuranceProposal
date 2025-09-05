using CreateProposalHiringKafka.Interfaces;
using Insurance.Domain.Interfaces.Application;

namespace CreateProposalHiringKafka.Transaction
{
    public class ExecuteTRA : IExecuteTRA
    {
        private readonly IConsumerService _consumerService;

        public ExecuteTRA(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        public void Execute()
        {
            _consumerService.ConsumeMessage();
        }
    }
}
