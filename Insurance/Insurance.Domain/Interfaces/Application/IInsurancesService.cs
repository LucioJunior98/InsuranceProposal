using Insurance.Domain.DTOs.Response;
using Insurance.Domain.Entities;
using Insurance.Domain.Enums;

namespace Insurance.Domain.Interfaces.Application
{
    public interface IInsurancesService
    {
        Task<BaseResponseDTO> CreateInsurances(Insurances insurances);

        Task<BaseResponseDTO> UpdateInsurances(long id, InsuranceStatus status, long? userId = null);

        Task<BaseResponseDTO> DeleteInsurances(long id, long? userId = null);

        Task<BaseResponseDTO> GetInsurancesById(long id);

        Task<BaseResponseDTO> GetInsurancesByStatus(InsuranceStatus status);

        Task<BaseResponseDTO> GetAllInsurances();
    }
}
