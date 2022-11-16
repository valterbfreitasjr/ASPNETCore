using CasaDoCodigo.Models;
using System.Collections.Generic;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}