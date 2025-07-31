using Projeto_Gabriel.Application.BusinessInterface;
using Projeto_Gabriel.Application.Converter.Implementacao;
using Projeto_Gabriel.Application.Dto;
using Projeto_Gabriel.Domain.RepositoryInterface;

namespace Projeto_Gabriel.Application.Business
{
    public class TaxaJurosBussinesImplementacao : ITaxaJurosBussines
    {
        private readonly ITaxaJurosRepository _taxaJurosRepository;
        private readonly TaxaJurosConverterRetorno _converterRetorno;
        private readonly TaxaJurosConverter _converter;

        public TaxaJurosBussinesImplementacao(
            ITaxaJurosRepository taxaJurosRepository,
            TaxaJurosConverter converter,
            TaxaJurosConverterRetorno converterRetorno)
        {
            _taxaJurosRepository = taxaJurosRepository;
            _converter = converter;
            _converterRetorno = converterRetorno;
        }

        public TaxaJurosDboRetorno AtualizarTaxaJuros(TaxaJurosDboEntrada taxaJuros, long usuarioid)
        {
            try
            {
                if (taxaJuros == null)
                    throw new ArgumentNullException(nameof(taxaJuros), "Taxa de juros não pode ser nula.");

                var taxaEntity = _converter.Parse(taxaJuros);

                var taxaAtualizada = _taxaJurosRepository.AtualizarTaxaJuros(taxaEntity, usuarioid);

                if (taxaAtualizada == null)
                    throw new Exception("Erro ao atualizar a taxa de juros.");

                return _converterRetorno.Parse(taxaAtualizada);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException("Dados inválidos para atualização da taxa de juros.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Usuário não autorizado a atualizar a taxa de juros.", ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException("Taxa de juros ou usuário não encontrado.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a taxa de juros.", ex);
            }
        }

        public TaxaJurosDboRetorno ObterTaxaJuros()
        {
            try
            {
                var taxa = _taxaJurosRepository.ObterTaxaJurosAtual();

                if (taxa == null)
                    throw new KeyNotFoundException("Nenhuma taxa de juros cadastrada.");

                return _converterRetorno.Parse(taxa);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException("Taxa de juros não encontrada.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter a taxa de juros.", ex);
            }
        }
    }
}
