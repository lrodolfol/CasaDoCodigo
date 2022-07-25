namespace CasaCodigo
{
    public class Relatorio : IRelatorio
    {
        private readonly ICatalago catalago;

        public Relatorio(ICatalago catalago)
        {
            this.catalago = catalago;
        }

        public async Task imprimir(HttpClient context)
        {

        }
    }
}
