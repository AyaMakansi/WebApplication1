using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model;

public class ApplicationsDbContext :DbContext
{
    public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options):base(options)
    {
    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
}