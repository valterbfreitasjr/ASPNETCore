using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo
{

    class DataService : IDataService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ApplicationContext _context;

        public DataService(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            this._context = context;
            this._produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            _context.Database.EnsureCreated();

            List<Livro> livros = GetLivros();

            _produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");

            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
