using Projeto_Gabriel.Application.Dto;

namespace Projeto_Gabriel.Application.BusinessInterface
{
    public interface ITaxaJurosBussines
    {
        TaxaJurosDboRetorno ObterTaxaJuros();

        TaxaJurosDboRetorno AtualizarTaxaJuros(TaxaJurosDboEntrada taxaJuros, long usuarioid);
    }
}