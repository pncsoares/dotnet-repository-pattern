using DataLayer.Core.Domain;

namespace DataLayer.Core.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Author GetAuthorWithCourses(int id);
}