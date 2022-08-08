using CasaDoCodigo.Models;

namespace Teste.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro>? livros);
        IList<Produto> GetProdutos();
    }
}