using Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro;
using Projeto_Gabriel.Domain.RepositoryInterface.GerenciamentoFinanceiro;
using Projeto_Gabriel.Infrastructure.Repositorys.Generic;
using Projeto_Gabriel.Model.Context;

namespace Projeto_Gabriel.Infrastructure.Repositorys.GerenciamentoFinanceiro
{
    public class TransacaoRepository : GenericRepositoryBase<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MySQLContext context) : base(context)
        {
        }

        public Task<decimal> ObterDespesaTotalPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> ObterFaturamentoTotalPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> ObterPorPeriodoAsync(int organizacaoId, DateTime inicio, DateTime fim)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> ObterUltimasTransacoesAsync(int organizacaoId, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}