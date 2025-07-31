using Projeto_Gabriel.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Gabriel.Domain.Entity
{
    [Table("taxaJuros")]
    public class TaxaJuros : BaseEntity
    {
        [Column("Juros")]
        public decimal Juros { get; set; }
    }
}