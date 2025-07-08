using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro;
using Projeto_Gabriel.Infrastructure.Repositorys.Generic;
using Projeto_Gabriel.Model.Context;
using System.Data.Entity;

namespace Projeto_Gabriel.Infrastructure.Repositorys.GerenciamentoFinanceiro
{
    public class FornecedorRepository : GenericRepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MySQLContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodosPorOrganizacaoAsync(int organizacaoId)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));

                var fornecedores = await _context.Fornecedores.Where(f => f.OrganizacaoId == organizacaoId).ToListAsync();

                if (fornecedores == null || !fornecedores.Any())
                    throw new KeyNotFoundException("Nenhum fornecedor encontrado para a organização informada.");

                return fornecedores;
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
                throw new Exception("Erro ao buscar fornecedores por organização.", ex);
            }
        }
    }
}