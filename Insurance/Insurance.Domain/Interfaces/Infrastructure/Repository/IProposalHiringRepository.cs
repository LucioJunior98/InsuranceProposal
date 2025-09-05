using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Infrastructure.Repository.Base;

namespace Insurance.Domain.Interfaces.Infrastructure.Repository
{
    public interface IProposalHiringRepository : IBaseRepository<ProposalHiring>
    {
        Task<ProposalHiring?> GetById(long id);

        Task<ProposalHiring?> GetByStatus(ProposalHiringStatus status);

        Task<List<ProposalHiring>> GetAllProposalHiring();

        Task<List<ProposalHiring>> GetAllByStatus(ProposalHiringStatus status);
    }
}
