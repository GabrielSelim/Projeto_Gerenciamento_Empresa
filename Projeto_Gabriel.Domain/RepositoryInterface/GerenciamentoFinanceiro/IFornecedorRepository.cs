using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.Generic;

namespace Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        /// <summary>
        /// Retorna todos os fornecedores filtrados por uma organização específica.
        /// ESSENCIAL para a arquitetura multi-tenant.
        /// </summary>
        Task<IEnumerable<Fornecedor>> ObterTodosPorOrganizacaoAsync(int organizacaoId);
    }
}