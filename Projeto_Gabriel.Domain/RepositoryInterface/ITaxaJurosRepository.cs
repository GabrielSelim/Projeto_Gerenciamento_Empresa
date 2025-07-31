using Projeto_Gabriel.Domain.Entity;
using Projeto_Gabriel.Repository.Generic;

namespace Projeto_Gabriel.Domain.RepositoryInterface
{
    public interface ITaxaJurosRepository : IRepository<TaxaJuros>
    {
        TaxaJuros ObterTaxaJurosAtual();

        TaxaJuros AtualizarTaxaJuros(TaxaJuros taxaJuros, long usuarioid);
    }
}