using CasaDoCodigo.Models;

namespace Teste.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(AppDbContext context) : base(context)
        {
        }
    }
}
