using Entity.Entity;
using System.Linq.Expressions;

namespace Infra.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity, new()
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(int id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
