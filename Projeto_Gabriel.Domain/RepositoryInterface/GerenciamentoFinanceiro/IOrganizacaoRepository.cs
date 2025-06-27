using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.Generic;

namespace Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro
{
    public interface IOrganizacaoRepository : IRepositoryBase<Organizacao>
    {
        /// <summary>
        /// Busca uma organização pelo seu CNPJ. Útil para validar no momento do cadastro.
        /// </summary>
        Task<Organizacao> ObterPorCnpjAsync(string cnpj);
    }
}