using System.Text.Json;
using Insurance.Domain.DTOs.Response;
using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Application;
using Insurance.Domain.Interfaces.Infrastructure.Repository;

namespace Insurance.Application.Services
{
    public class ProposalHiringService : IProposalHiringService
    {
        private readonly IProposalHiringRepository _proposalHiringRepository;
        private readonly IInsurancesRepository _insurancesRepository;
        private readonly IProducerService _producerService;

        public ProposalHiringService(IProposalHiringRepository proposalHiringRepository, IInsurancesRepository insurancesRepository, IProducerService producerService)
        {
            _proposalHiringRepository = proposalHiringRepository;
            _insurancesRepository = insurancesRepository;
            _producerService = producerService;
        }

        public async Task<BaseResponseDTO> CreateProposalHiring(ProposalHiring proposalHiring)
        {
            BaseResponseDTO response = new BaseResponseDTO();
            _proposalHiringRepository.BeginTransaction();

            try
            {
                Insurances insurances = await _insurancesRepository.GetById(proposalHiring.InsurancesId) ?? throw new Exception("Não foi encontrado Proposta de Seguro !");

                if(insurances.Status != InsuranceStatus.Approved)
                    throw new Exception("A Proposta de Seguro precisa estar com o status Aprovado para ser contratado !");  

                //string proposalHiringJson = JsonSerializer.Serialize(proposalHiring);

                //string result = _producerService.GenerateMessage(proposalHiringJson);

                _proposalHiringRepository.Save(proposalHiring);

                _proposalHiringRepository.CommitTransaction();

                response.Success = true;
                response.Message = result;
            }
            catch (Exception ex)
            {
                _proposalHiringRepository.RollbackTransaction();

                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }

        public async Task<BaseResponseDTO> UpdateProposalHiring(long id, ProposalHiringStatus status, long? userId = null)
        {
            BaseResponseDTO response = new BaseResponseDTO();
            _proposalHiringRepository.BeginTransaction();

            try
            {
                ProposalHiring proposalHiring = await _proposalHiringRepository.GetById(id);

                if (proposalHiring == null)
                    throw new Exception("Seguro informado, não encontrado");
                else
                {
                    proposalHiring.UpdateDate = DateTime.Now;
                    proposalHiring.Status = status;
                }

                _proposalHiringRepository.Update(proposalHiring);

                _proposalHiringRepository.CommitTransaction();

                response.Success = true;
                response.Message = "Insurances update successfully.";
            }
            catch (Exception ex)
            {
                _proposalHiringRepository.RollbackTransaction();

                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }

        public async Task<BaseResponseDTO> DeleteProposalHiring(long id, long? userId = null)
        {
            BaseResponseDTO response = new BaseResponseDTO();
            _proposalHiringRepository.BeginTransaction();

            try
            {
                ProposalHiring proposalHiring = await _proposalHiringRepository.GetById(id);

                if (proposalHiring == null)
                    throw new Exception("Seguro informado, não encontrado");
                else
                {
                    proposalHiring.DeletionDate = DateTime.Now;
                    proposalHiring.UpdateDate = DateTime.Now;
                }

                _proposalHiringRepository.Delete(proposalHiring);

                _proposalHiringRepository.CommitTransaction();

                response.Success = true;
                response.Message = "ProposalHiring created successfully.";
            }
            catch (Exception ex)
            {
                _proposalHiringRepository.RollbackTransaction();

                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }

        public async Task<BaseResponseDTO> GetAllProposalHiring()
        {
            BaseResponseDTO response = new BaseResponseDTO();

            try
            {
                List<ProposalHiring> proposalHiring = await _proposalHiringRepository.GetAllProposalHiring();

                if (proposalHiring is null)
                {
                    response.Success = false;
                    response.Message = "Seguros não encontrado ou inexistente";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Seguros encontrado com sucesso.";
                    response.Data = proposalHiring;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }

        public Task<BaseResponseDTO> GetProposalHiringByStatus(ProposalHiringStatus status)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseDTO> GetProposalHiringId(long id)
        {
            BaseResponseDTO response = new BaseResponseDTO();

            try
            {
                ProposalHiring proposalHiring = await _proposalHiringRepository.GetById(id);

                if (proposalHiring is null)
                {
                    response.Success = false;
                    response.Message = "Seguros não encontrado ou inexistente";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Seguros encontrado com sucesso.";
                    response.Data = proposalHiring;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }
    }
}
