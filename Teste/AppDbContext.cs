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

            builder.Entity<Produto>().HasKey(p => p.Id);

            builder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(p => p.Pedido);
            //builder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(p => p.Pedido);
            
            builder.Entity<ItemPedido>().HasKey(i => i.Id);
            builder.Entity<ItemPedido>().HasOne(i => i.Pedido);
            builder.Entity<ItemPedido>().HasOne(i => i.Produto);

            builder.Entity<Cadastro>().HasKey(c => c.Id);
            builder.Entity<Cadastro>().HasOne(c => c.Pedido);
        }
    }
}
