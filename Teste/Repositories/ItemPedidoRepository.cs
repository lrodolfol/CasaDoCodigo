using CasaDoCodigo.Models;

namespace Teste.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
