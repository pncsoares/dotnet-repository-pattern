using DataLayer.Core.Repositories;

namespace DataLayer.Core;

public interface IUnitOfWork : IDisposable
{
    ICourseRepository Courses { get; }
    IAuthorRepository Authors { get; }
    int Complete();
}