using Projeto_Gabriel.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class Produto : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecoVenda { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecoCusto { get; set; }

        [StringLength(50)]
        public string? Sku { get; set; }

        [StringLength(10)]
        public string? UnidadeMedida { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QuantidadeEstoque { get; set; }

        [ForeignKey("Organizacao")]
        public int OrganizacaoId { get; set; }


        //Entity Framework Relationships
        public virtual Organizacao Organizacao { get; set; }
    }
}