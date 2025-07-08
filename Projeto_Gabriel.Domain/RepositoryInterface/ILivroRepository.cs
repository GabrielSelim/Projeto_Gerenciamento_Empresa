using Projeto_Gabriel.Domain.Generic;

namespace Projeto_Gabriel.Domain.RepositoryInterface
{
    public interface ILivroRepository : IRepositoryBase<Livros>
    {
        Livros Desativar(long id);

        Livros Ativar(long id);

        List<Livros> ObterLivrosPorAutor(string autor);

        List<Livros> ObterLivrosPorTitulo(string titulo);

        List<Livros> ObterLivrosPorDataLancamento(DateTime dataLancamento);

        List<Livros> ObterLivrosPorPreco(decimal preco);
    }
}