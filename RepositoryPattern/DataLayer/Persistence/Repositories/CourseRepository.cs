using DataLayer.Core.Domain;
using DataLayer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Persistence.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(DbContext context) : base(context)
    {
    }

    public IEnumerable<Course> GetTopSellingCourses(int count)
    {
        return PlutoContext.Courses
            .OrderByDescending(c => c.FullPrice)
            .Take(count)
            .ToList();
    }

    public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
    {
        return PlutoContext.Courses
            .Include(c => c.Author)
            .OrderBy(c => c.Name)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    private PlutoContext PlutoContext => Context as PlutoContext;
}