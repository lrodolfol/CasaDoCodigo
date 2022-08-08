using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;

namespace Teste.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private IHttpContextAccessor httpContextAccessor;
        public PedidoRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        private int GetPedidoId()
        {
            return (int)httpContextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            httpContextAccessor.HttpContext.Session.SetInt32("pedidoId",pedidoId);
        }
    }
}
