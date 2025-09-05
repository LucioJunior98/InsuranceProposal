using System.Numerics;
using Insurance.Domain.DTOs.Response;
using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Application;
using Insurance.Domain.Interfaces.Infrastructure.Repository;

namespace Insurance.Application.Services
{
    public class InsurancesService : IInsurancesService
    {
        private readonly IInsurancesRepository _insurancesRepository;

        public InsurancesService(IInsurancesRepository insurancesRepository)
        {
            _insurancesRepository = insurancesRepository;
        }

        public async Task<BaseResponseDTO> CreateInsurances(Insurances insurances)
        {
            BaseResponseDTO response = new BaseResponseDTO();

            _insurancesRepository.BeginTransaction();

            try
            {
                _insurancesRepository.Save(insurances);

                _insurancesRepository.CommitTransaction();

                response.Success = true;
                response.Message = "Insurances created successfully.";
            }
            catch (Exception ex)
            {
                _insurancesRepository.RollbackTransaction();    

                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }

        public async Task<BaseResponseDTO> UpdateInsurances(long id, InsuranceStatus status, long? userId = null)
        {
            BaseResponseDTO response = new BaseResponseDTO();
            _insurancesRepository.BeginTransaction();

            try
            {
                Insurances insurance = await _insurancesRepository.GetById(id);

                if (insurance == null)
                    throw new Exception("Seguro informado, não encontrado");
                else
                {
                    insurance.UpdateDate = DateTime.Now;
                    insurance.Status = status;
                }

                _insurancesRepository.Update(insurance);

                _insurancesRepository.CommitTransaction();

                response.Success = true;
                response.Message = "Insurances update successfully.";
            }
            catch (Exception ex)
            {
                _insurancesRepository.RollbackTransaction();

                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }

        public async Task<BaseResponseDTO> DeleteInsurances(long id, long? userId = null)
        {
            BaseResponseDTO response = new BaseResponseDTO();
            _insurancesRepository.BeginTransaction();

            try
            {
                Insurances insurance = await _insurancesRepository.GetById(id);

                if(insurance == null)
                    throw new Exception("Seguro informado, não encontrado");
                else
                {
                    insurance.DeletionDate = DateTime.Now;
                    insurance.UpdateDate = DateTime.Now;
                }

                _insurancesRepository.Delete(insurance);

                _insurancesRepository.CommitTransaction();
            }
            catch (Exception ex)
            {
                _insurancesRepository.RollbackTransaction();

                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }

            return response;
        }

        public async Task<BaseResponseDTO> GetAllInsurances()
        {
            BaseResponseDTO response = new BaseResponseDTO();

            try
            {
                List<Insurances> insurances = await _insurancesRepository.GetAllInsurances();

                if (insurances is null)
                {
                    response.Success = false;
                    response.Message = "Seguros não encontrado ou inexistente";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Seguros encontrado com sucesso.";
                    response.Data = insurances;
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

        public async Task<BaseResponseDTO> GetInsurancesById(long id)
        {
            BaseResponseDTO response = new BaseResponseDTO();

            try
            {
                Insurances insurances = await _insurancesRepository.GetById(id);

                if (insurances is null)
                {
                    response.Success = false;
                    response.Message = "Seguros não encontrado ou inexistente";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Seguros encontrado com sucesso.";
                    response.Data = insurances;
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

        public Task<BaseResponseDTO> GetInsurancesByStatus(InsuranceStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
