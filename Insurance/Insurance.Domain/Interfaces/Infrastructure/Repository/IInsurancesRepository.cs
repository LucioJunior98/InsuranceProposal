using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Infrastructure.Repository.Base;

namespace Insurance.Domain.Interfaces.Infrastructure.Repository
{
    public interface IInsurancesRepository : IBaseRepository<Insurances>
    {
        Task<Insurances?> GetById(long id);

        Task<Insurances?> GetByStatus(InsuranceStatus status);

        Task<List<Insurances>> GetAllInsurances();
    }
}
