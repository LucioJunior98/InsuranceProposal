namespace Insurance.Domain.Interfaces.Infrastructure.Repository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        void Save(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
