using CreateProposalHiringKafka.Interfaces;
using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Application;
using Insurance.Domain.Interfaces.Infrastructure.Repository;

namespace CreateProposalHiringKafka.Transaction
{
    public class ExecuteTRA : IExecuteTRA
    {
        private readonly IConsumerService _consumerService;
        private readonly IProposalHiringService _proposalHiringService;
        private readonly IProposalHiringRepository _proposalHiringRepository;

        public ExecuteTRA(IConsumerService consumerService, IProposalHiringService proposalHiringService, IProposalHiringRepository proposalHiringRepository)
        {
            _consumerService = consumerService;
            _proposalHiringService = proposalHiringService;
            _proposalHiringRepository = proposalHiringRepository;
        }

        public async Task Execute()
        {
            // Fluxo Kafka
            //_consumerService.ConsumeMessage();

            try
            {
                bool haveMessage = _consumerService.ConsumeMessage().Result;
                
                if (!haveMessage)
                {
                    List<ProposalHiring> proposalHirings = await _proposalHiringRepository.GetAllByStatus(ProposalHiringStatus.InProgress);

                    foreach (ProposalHiring proposalHiring in proposalHirings)
                    {
                        try
                        {
                            await _proposalHiringService.UpdateProposalHiring(proposalHiring.Id, ProposalHiringStatus.Completed, 2);
                        }
                        catch
                        {
                            await _proposalHiringService.UpdateProposalHiring(proposalHiring.Id, ProposalHiringStatus.Cancelled, 2);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
