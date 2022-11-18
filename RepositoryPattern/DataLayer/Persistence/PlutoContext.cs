using DataLayer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Persistence;

public class PlutoContext : DbContext
{
    public PlutoContext(DbContextOptions options) : base(options)
    {
    }
    
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
}