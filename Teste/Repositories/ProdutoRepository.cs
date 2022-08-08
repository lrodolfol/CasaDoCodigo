using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace Teste.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro>? livros)
        {
            foreach (var livro in livros)
            {
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    Produto p = new Produto(
                        livro.Codigo,
                        livro.Nome,
                        livro.Preco
                        );
                    dbSet.Add(p);
                }


            }
            _context.SaveChanges();
        }
    }
}

public class Livro
{
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
