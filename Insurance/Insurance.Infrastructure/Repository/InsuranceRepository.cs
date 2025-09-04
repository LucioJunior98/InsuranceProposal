using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Infrastructure.Repository;
using Insurance.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Insurance.Infrastructure.Repository
{
    public class InsuranceRepository : AppDbContext, IInsurancesRepository
    {
        private Task<IDbContextTransaction> _transaction { get; set; }

        public InsuranceRepository(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            if (_transaction is not null)
                _transaction.Result.Commit();
        }

        public void RollbackTransaction()
        {
            if (_transaction is not null)
                _transaction.Result.Rollback();
        }

        public async Task<List<Insurances>> GetAllInsurances()
        {
            return await Insurances.Where(x => x.DeletionDate == null).ToListAsync();
        }

        public async Task<Insurances?> GetById(long id)
        {
            return await Insurances.FirstOrDefaultAsync(x => x.Id == id && x.DeletionDate == null);
        }

        public async Task<Insurances?> GetByStatus(InsuranceStatus status)
        {
            return await Insurances.FirstOrDefaultAsync(x => x.Status == status && x.DeletionDate == null);
        }

        public void Save(Insurances insurances)
        {
            try
            {
                Insurances.Add(insurances);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Insurances insurances)
        {
            try
            {
                Insurances.Update(insurances);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Insurances insurances)
        {
            try
            {
                Insurances.Update(insurances);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
