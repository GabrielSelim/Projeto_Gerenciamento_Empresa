using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro;
using Projeto_Gabriel.Infrastructure.Repositorys.Generic;
using Projeto_Gabriel.Model.Context;
using System.Data.Entity;

namespace Projeto_Gabriel.Infrastructure.Repositorys.GerenciamentoFinanceiro
{
    public class ProdutoRepository : GenericRepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MySQLContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> ObterTodosPorOrganizacaoAsync(int organizacaoId)
        {
            if (organizacaoId <= 0)
                throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));

            return await _context.Produtos.Where(p => p.OrganizacaoId == organizacaoId).ToListAsync();
        }
        public async Task<IEnumerable<Produto>> GetProdutosComEstoqueBaixoAsync(int organizacaoId, decimal limiteEstoque)
        {
            if (organizacaoId <= 0)
                throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));

            return await _context.Produtos.Where(p => p.OrganizacaoId == organizacaoId && p.QuantidadeEstoque < limiteEstoque).ToListAsync();
        }
        public async Task<Produto> ObterPorSkuAsync(int organizacaoId, string sku)
        {
            if (organizacaoId <= 0)
                throw new ArgumentException("O ID da organização deve ser maior que zero.", nameof(organizacaoId));

            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException("O SKU não pode ser vazio.", nameof(sku));

            return await _context.Produtos.FirstOrDefaultAsync(p => p.OrganizacaoId == organizacaoId && p.Sku == sku);
        }
    }
}