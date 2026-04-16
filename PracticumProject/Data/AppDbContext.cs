using Microsoft.EntityFrameworkCore;

    namespace PracticumProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}