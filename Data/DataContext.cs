using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.DotNet8.Entities;

namespace SuperHeroAPI.DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
            {
            
            }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}