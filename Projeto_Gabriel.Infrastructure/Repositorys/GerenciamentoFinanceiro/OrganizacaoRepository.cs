using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro;
using Projeto_Gabriel.Infrastructure.Repositorys.Generic;
using Projeto_Gabriel.Model.Context;
using System.Data.Entity;

namespace Projeto_Gabriel.Infrastructure.Repositorys.GerenciamentoFinanceiro
{
    public class OrganizacaoRepository : GenericRepositoryBase<Organizacao>, IOrganizacaoRepository
    {
        public OrganizacaoRepository(MySQLContext context) : base(context)
        {
        }

        public async Task<Organizacao> ObterPorCnpjAsync(string cnpj)
        {
            try
            {
                var organizacao = await _context.Set<Organizacao>().FirstOrDefaultAsync(p => p.Cnpj == cnpj);

                return organizacao == null ? throw new KeyNotFoundException("Organização não encontrada para o CNPJ informado.") : organizacao;
            }
            catch (ArgumentException ex)
            {
                throw;
            }
            catch (KeyNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar organização por CNPJ.", ex);
            }
        }
    }
}