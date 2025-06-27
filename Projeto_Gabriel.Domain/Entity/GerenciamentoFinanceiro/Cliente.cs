using Projeto_Gabriel.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class Cliente : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(18)]
        public string? CpfCnpj { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Telefone { get; set; }

        [ForeignKey("Organizacao")]
        public int OrganizacaoId { get; set; }


        // Entity Framework Relationships
        public virtual Organizacao Organizacao { get; set; }
    }
}