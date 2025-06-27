using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.Generic;
using Projeto_Gabriel.Repository.Generic;

namespace Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro
{
    public interface ITransacaoRepository : IRepositoryBase<Transacao>
    {
        /// <summary>
        /// Retorna todas as transações (receitas e despesas) de um período para uma organização.
        /// A base para a maioria dos relatórios financeiros.
        /// </summary>
        Task<IEnumerable<Transacao>> ObterPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim);

        /// <summary>
        /// Retorna o faturamento total (soma de todas as receitas) em um período para um relatório rápido.
        /// </summary>
        Task<decimal> ObterFaturamentoTotalPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim);

        /// <summary>
        /// Retorna a despesa total em um período para um relatório rápido.
        /// </summary>
        Task<decimal> ObterDespesaTotalPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim);

        /// <summary>
        /// Busca as últimas N transações de uma organização para exibir em um dashboard.
        /// </summary>
        Task<IEnumerable<Transacao>> ObterUltimasTransacoesAsync(int organizacaoId, int quantidade);
    }
}