using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro;
using Projeto_Gabriel.Infrastructure.Repositorys.Generic;
using Projeto_Gabriel.Model.Context;
using System.Data.Entity;

namespace Projeto_Gabriel.Infrastructure.Repositorys.GerenciamentoFinanceiro
{
    public class ClienteRepository : GenericRepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(MySQLContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ObterTodosPorOrganizacaoAsync(int organizacaoId)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));

                var clientes = await _context.Clientes
                    .Where(c => c.OrganizacaoId == organizacaoId)
                    .ToListAsync();

                if (clientes == null || clientes.Count == 0)
                    throw new KeyNotFoundException("Nenhum cliente encontrado para a organização informada.");

                return clientes;
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
                throw new Exception("Erro ao buscar clientes por organização.", ex);
            }
        }

        public async Task<IEnumerable<Cliente>> BuscarPorNomeAsync(int organizacaoId, string nome)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));

                if (string.IsNullOrWhiteSpace(nome))
                    throw new ArgumentException("O nome para busca não pode ser vazio.", nameof(nome));

                var clientes = await _context.Clientes
                    .Where(c => c.OrganizacaoId == organizacaoId && c.Nome.Contains(nome))
                    .ToListAsync();

                if (clientes == null || clientes.Count == 0)
                    throw new KeyNotFoundException("Nenhum cliente encontrado com o nome informado.");

                return clientes;
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
                throw new Exception("Erro ao buscar clientes por nome.", ex);
            }
        }

        public async Task<Cliente> ObterPorDocumentoAsync(int organizacaoId, string documento)
        {
            try
            {
                if (organizacaoId <= 0)
                    throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));

                if (string.IsNullOrWhiteSpace(documento))
                    throw new ArgumentException("O documento não pode ser vazio.", nameof(documento));

                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.OrganizacaoId == organizacaoId && c.CpfCnpj == documento);

                if (cliente == null)
                    throw new KeyNotFoundException("Cliente não encontrado para o documento informado.");

                return cliente;
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
                throw new Exception("Erro ao buscar cliente por documento.", ex);
            }
        }
    }
}