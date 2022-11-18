using DataLayer.Core.Domain;
using DataLayer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Persistence.Repositories;

public class AuthorRepository: Repository<Author>, IAuthorRepository
{
    public AuthorRepository(DbContext context) : base(context)
    {
    }

    public Author GetAuthorWithCourses(int id)
    {
        return PlutoContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == id);
    }

    private PlutoContext PlutoContext => Context as PlutoContext;
}