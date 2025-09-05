using Insurance.Domain.DTOs.Response;
using Insurance.Domain.Entities;
using Insurance.Domain.Enums;

namespace Insurance.Domain.Interfaces.Application
{
    public interface IProposalHiringService
    {
        Task<BaseResponseDTO> CreateProposalHiring(ProposalHiring proposalHiring);

        Task<BaseResponseDTO> UpdateProposalHiring(long id, ProposalHiringStatus status, long? userId = null);

        Task<BaseResponseDTO> DeleteProposalHiring(long id, long? userId = null);

        Task<BaseResponseDTO> GetProposalHiringId(long id);

        Task<BaseResponseDTO> GetProposalHiringByStatus(ProposalHiringStatus status);

        Task<BaseResponseDTO> GetAllProposalHiring();
    }
}
