using System.Linq.Expressions;

namespace DataLayer.Core.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity Get(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}