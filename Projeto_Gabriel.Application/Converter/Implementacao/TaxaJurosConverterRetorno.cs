using Projeto_Gabriel.Application.Converter.Contrato;
using Projeto_Gabriel.Application.Dto;
using Projeto_Gabriel.Domain.Entity;

namespace Projeto_Gabriel.Application.Converter.Implementacao
{
    public class TaxaJurosConverterRetorno : IParser<TaxaJurosDboRetorno, TaxaJuros>, IParser<TaxaJuros, TaxaJurosDboRetorno>
    {
        public TaxaJuros Parse(TaxaJurosDboRetorno origem)
        {
            if (origem == null) return null;

            return new TaxaJuros
            {
                Juros = origem.Juros
            };
        }

        public TaxaJurosDboRetorno Parse(TaxaJuros origem)
        {
            if (origem == null) return null;

            return new TaxaJurosDboRetorno
            {
                Juros = origem.Juros
            };
        }

        public List<TaxaJuros> ParseList(List<TaxaJurosDboRetorno> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }

        public List<TaxaJurosDboRetorno> ParseList(List<TaxaJuros> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}