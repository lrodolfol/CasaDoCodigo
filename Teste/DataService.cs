using CasaDoCodigo.Models;
using Newtonsoft.Json;
using Teste;
using Teste.Repositories;

public class DataService : IDataService
{

    private readonly IProdutoRepository _repo;

    public DataService(IProdutoRepository repo)
    {
        _repo = repo;
    }

    public void InicializaDb()
    {
        List<Livro>? livros = GetLivros();

        _repo.SaveProdutos(livros);

        Console.WriteLine("Banco preenchido!");
    }

    private static List<Livro>? GetLivros()
    {
        var json = File.ReadAllText("livros.json");
        var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
        return livros;
    }


}

