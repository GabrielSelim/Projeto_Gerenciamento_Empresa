using Projeto_Gabriel.Domain.Entity;
using Projeto_Gabriel.Domain.RepositoryInterface;
using Projeto_Gabriel.Model.Context;
using Projeto_Gabriel.Repository.Generic;

namespace Projeto_Gabriel.Infrastructure.Repositorys
{
    public class TaxaJurosRepository : GenericRepository<TaxaJuros>, ITaxaJurosRepository
    {
        private readonly MySQLContext _context;

        public TaxaJurosRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public TaxaJuros AtualizarTaxaJuros(TaxaJuros taxaJuros, long usuarioid)
        {
            try
            {
                if (taxaJuros == null)
                    throw new ArgumentNullException(nameof(taxaJuros), "Taxa de juros não pode ser nula.");

                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == usuarioid);
                if (usuario == null)
                    throw new KeyNotFoundException("Usuário não encontrado.");

                if (!string.Equals(usuario.Role, "Admin", StringComparison.OrdinalIgnoreCase))
                    throw new UnauthorizedAccessException("Apenas usuários administradores podem atualizar a taxa de juros.");

                var taxaAtual = _context.TaxaJuros.FirstOrDefault(t => t.Id == taxaJuros.Id);
                if (taxaAtual == null)
                    throw new KeyNotFoundException("Taxa de juros não encontrada.");

                taxaAtual.Juros = taxaJuros.Juros;
                _context.TaxaJuros.Update(taxaAtual);
                _context.SaveChanges();

                return taxaAtual;
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw;
            }
            catch (KeyNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a taxa de juros.", ex);
            }
        }

        public TaxaJuros ObterTaxaJurosAtual()
        {
            try
            {
                var taxaAtual = _context.TaxaJuros
                    .OrderByDescending(t => t.Id)
                    .FirstOrDefault();

                if (taxaAtual == null)
                    throw new KeyNotFoundException("Nenhuma taxa de juros cadastrada.");

                return taxaAtual;
            }
            catch (KeyNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter a taxa de juros atual.", ex);
            }
        }
    }
}