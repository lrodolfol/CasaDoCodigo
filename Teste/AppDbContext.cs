using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace Teste
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Produto>()
                .HasKey(p => p.Id);

        }
    }
}
