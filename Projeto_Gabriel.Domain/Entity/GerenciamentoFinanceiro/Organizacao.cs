using Projeto_Gabriel.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class Organizacao : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string NomeFantasia { get; set; }

        [StringLength(100)]
        public string RazaoSocial { get; set; }

        [StringLength(18)] // Formato CNPJ: 00.000.000/0000-00
        public string Cnpj { get; set; }

        public string LogoUrl { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;


        //Entity Framework Relationships
        public virtual ICollection<ApplicationUser> Usuarios { get; set; } = new List<ApplicationUser>();
        public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        public virtual ICollection<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}