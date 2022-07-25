namespace CasaCodigo
{
    public class Catalago : ICatalago
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Quem mexeu na minha query?", 12.99m));
            livros.Add(new Livro("002", "Fique rico com C#?", 18.99m));
            livros.Add(new Livro("003", "Java para baixinhos?", 92.99m));

            return livros;
        }
    }
}
