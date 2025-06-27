using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projeto_Gabriel.Domain.Entity.Base;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class Fornecedor : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string NomeFantasia { get; set; }

        // Chave Estrangeira
        [ForeignKey("Organizacao")]
        public int OrganizacaoId { get; set; }


        //Entiy Framework Relationships
        public virtual Organizacao Organizacao { get; set; }
    }
}