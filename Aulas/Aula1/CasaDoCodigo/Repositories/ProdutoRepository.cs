using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    //context.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));  -- context.Set<Produto>() virou dbSet após extrair para uma variável
                                                                                          // local, então levando ela para a BaseRepository<T> e herdando de BaseRepository.
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            _context.SaveChanges();
        }

        public class Livro
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }
    }
}
