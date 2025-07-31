using Projeto_Gabriel.Application.Converter.Contrato;
using Projeto_Gabriel.Application.Dto;
using Projeto_Gabriel.Domain.Entity;

namespace Projeto_Gabriel.Application.Converter.Implementacao
{
    public class TaxaJurosConverter : IParser<TaxaJurosDboEntrada, TaxaJuros>, IParser<TaxaJuros, TaxaJurosDboEntrada>
    {
        public TaxaJuros Parse(TaxaJurosDboEntrada origem)
        {
            if (origem == null) return null;

            return new TaxaJuros
            {
                Juros = origem.Juros
            };
        }

        public TaxaJurosDboEntrada Parse(TaxaJuros origem)
        {
            if (origem == null) return null;

            return new TaxaJurosDboEntrada
            {
                Juros = origem.Juros
            };
        }

        public List<TaxaJuros> ParseList(List<TaxaJurosDboEntrada> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }

        public List<TaxaJurosDboEntrada> ParseList(List<TaxaJuros> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}