using Projeto_Gabriel.Domain.Entity.Base;
using Projeto_Gabriel.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class Transacao : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public TipoTransacao Tipo { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }

        // Chaves Estrangeiras
        [ForeignKey("Organizacao")]
        public int OrganizacaoId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; } // Quem registrou

        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; } // Nullable, pois uma despesa não tem cliente

        [ForeignKey("Fornecedor")]
        public int? FornecedorId { get; set; } // Nullable, pois uma venda não tem fornecedor


        // Entity Framework Relationships
        public virtual Organizacao Organizacao { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}