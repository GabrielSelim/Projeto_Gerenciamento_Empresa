using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.Generic;
using Projeto_Gabriel.Repository.Generic;

namespace Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        /// <summary>
        /// Retorna todos os produtos filtrados por uma organização específica.
        /// ESSENCIAL para a arquitetura multi-tenant.
        /// </summary>
        Task<IEnumerable<Produto>> ObterTodosPorOrganizacaoAsync(int organizacaoId);

        /// <summary>
        /// Retorna produtos com quantidade em estoque abaixo de um certo limite para uma organização.
        /// Útil para dashboards de alerta.
        /// </summary>
        Task<IEnumerable<Produto>> GetProdutosComEstoqueBaixoAsync(int organizacaoId, decimal limiteEstoque);

        /// <summary>
        /// Busca um produto pelo seu código SKU (código de barras) dentro de uma organização.
        /// Garante que o SKU de uma empresa não se confunda com o de outra.
        /// </summary>
        Task<Produto> ObterPorSkuAsync(int organizacaoId, string sku);
    }
}