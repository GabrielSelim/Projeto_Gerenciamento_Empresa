using System.ComponentModel.DataAnnotations;

namespace Projeto_Gabriel.Application.Dto
{
    public class TaxaJurosDboEntrada
    {
        [Required]
        public decimal Juros { get; set; }
    }
}