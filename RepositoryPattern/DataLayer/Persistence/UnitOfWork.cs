using DataLayer.Core;
using DataLayer.Core.Repositories;
using DataLayer.Persistence.Repositories;

namespace DataLayer.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly PlutoContext _context;

    public UnitOfWork(PlutoContext context)
    {
        _context = context;
        Courses = new CourseRepository(_context);
        Authors = new AuthorRepository(_context);
    }

    public ICourseRepository Courses { get; }
    public IAuthorRepository Authors { get; }
    
    public int Complete()
    {
        return _context.SaveChanges();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}