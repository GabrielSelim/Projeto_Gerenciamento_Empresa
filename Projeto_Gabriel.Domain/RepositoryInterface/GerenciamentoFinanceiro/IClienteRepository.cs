using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.Generic;
using Projeto_Gabriel.Repository.Generic;

namespace Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        /// <summary>
        /// Retorna todos os clientes filtrados por uma organização específica.
        /// ESSENCIAL para a arquitetura multi-tenant.
        /// </summary>
        Task<IEnumerable<Cliente>> ObterTodosPorOrganizacaoAsync(int organizacaoId);

        /// <summary>
        /// Busca clientes por parte do nome dentro de uma organização.
        /// Útil para funcionalidades de busca na interface.
        /// </summary>
        Task<IEnumerable<Cliente>> BuscarPorNomeAsync(int organizacaoId, string nome);

        /// <summary>
        /// Busca um cliente pelo CPF ou CNPJ dentro de uma organização.
        /// Importante para evitar cadastros duplicados.
        /// </summary>
        Task<Cliente> ObterPorDocumentoAsync(int organizacaoId, string documento);
    }
}