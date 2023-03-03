using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }

    }
}
