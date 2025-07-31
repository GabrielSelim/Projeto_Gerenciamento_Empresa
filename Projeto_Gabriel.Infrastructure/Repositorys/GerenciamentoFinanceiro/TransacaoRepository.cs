using Projeto_Gabriel.Domain.Entity.Enum;
using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro;
using Projeto_Gabriel.Infrastructure.Repositorys.Generic;
using Projeto_Gabriel.Model.Context;
using System.Data.Entity;

namespace Projeto_Gabriel.Infrastructure.Repositorys.GerenciamentoFinanceiro
{
    public class TransacaoRepository : GenericRepositoryBase<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MySQLContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Transacao>> ObterPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));
                if (inicio > fim)
                    throw new ArgumentException("A data de início não pode ser maior que a data de fim.");

                var transacoes = await _context.Set<Transacao>()
                    .Where(t => t.OrganizacaoId == organizacaoId && t.Data >= inicio && t.Data <= fim)
                    .ToListAsync();

                if (transacoes == null || transacoes.Count == 0)
                    throw new KeyNotFoundException("Nenhuma transação encontrada para o período informado.");

                return transacoes;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar transações por período.", ex);
            }
        }

        public async Task<decimal> ObterFaturamentoTotalPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));
                if (inicio > fim)
                    throw new ArgumentException("A data de início não pode ser maior que a data de fim.");

                var total = await _context.Set<Transacao>()
                    .Where(t => t.OrganizacaoId == organizacaoId && t.Data >= inicio && t.Data <= fim && t.Tipo == TipoTransacao.Receita)
                    .SumAsync(t => (decimal?)t.Valor ?? 0);

                return total;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular o faturamento total por período.", ex);
            }
        }

        public async Task<decimal> ObterDespesaTotalPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));
                if (inicio > fim)
                    throw new ArgumentException("A data de início não pode ser maior que a data de fim.");

                var total = await _context.Set<Transacao>()
                    .Where(t => t.OrganizacaoId == organizacaoId && t.Data >= inicio && t.Data <= fim && t.Tipo == TipoTransacao.Despesa)
                    .SumAsync(t => (decimal?)t.Valor ?? 0);

                return total;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular a despesa total por período.", ex);
            }
        }

        public async Task<IEnumerable<Transacao>> ObterUltimasTransacoesAsync(int organizacaoId, int quantidade)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));
                if (quantidade <= 0)
                    throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));

                var transacoes = await _context.Set<Transacao>()
                    .Where(t => t.OrganizacaoId == organizacaoId)
                    .OrderByDescending(t => t.Data)
                    .Take(quantidade)
                    .ToListAsync();

                if (transacoes == null || transacoes.Count == 0)
                    throw new KeyNotFoundException("Nenhuma transação encontrada para a organização informada.");

                return transacoes;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar as últimas transações.", ex);
            }
        }
    }
}