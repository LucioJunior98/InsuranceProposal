using Insurance.Domain.Entities;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces.Infrastructure.Repository;
using Insurance.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Insurance.Infrastructure.Repository
{
    public class ProposalHiringRepository : AppDbContext, IProposalHiringRepository
    {
        private Task<IDbContextTransaction> _transaction { get; set; }

        public ProposalHiringRepository(DbContextOptions<AppDbContext> options) : base(options) { }

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

        public async Task<List<ProposalHiring>> GetAllProposalHiring()
        {
            return await ProposalHiring.Where(x => x.DeletionDate == null).ToListAsync();
        }

        public async Task<ProposalHiring?> GetById(long id)
        {
            return await ProposalHiring.FirstOrDefaultAsync(x => x.Id == id && x.DeletionDate == null);
        }

        public async Task<ProposalHiring?> GetByStatus(ProposalHiringStatus status)
        {
            return await ProposalHiring.FirstOrDefaultAsync(x => x.Status == status && x.DeletionDate == null);
        }

        public async Task<List<ProposalHiring>> GetAllByStatus(ProposalHiringStatus status)
        {
            return await ProposalHiring.Where(x => x.Status == status && x.DeletionDate == null).ToListAsync();
        }

        public void Save(ProposalHiring proposalHiring)
        {
            try
            {
                ProposalHiring.Add(proposalHiring);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ProposalHiring proposalHiring)
        {
            try
            {
                ProposalHiring.Update(proposalHiring);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(ProposalHiring proposalHiring)
        {
            try
            {
                ProposalHiring.Update(proposalHiring);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
