using DataLayer.Core.Domain;

namespace DataLayer.Core.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    IEnumerable<Course> GetTopSellingCourses(int count);
    IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
}