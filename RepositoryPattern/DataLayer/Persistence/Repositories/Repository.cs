using System.Linq.Expressions;
using DataLayer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;

    public Repository(DbContext context)
    {
        Context = context;
    }

    public TEntity Get(int id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    /// <summary>
    /// We are returning IEnumerable and not IQueryable
    /// Returning IQueryable allows developers to modify the query returned and we do not want that
    /// Because in other layers such as Services or Business we do not want to query
    /// Instead we must return IEnumerable
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }

    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().SingleOrDefault(predicate);
    }

    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().RemoveRange(entities);
    }
}