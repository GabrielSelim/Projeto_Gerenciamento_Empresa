using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "O Nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A organização é obrigatória.")]
        public int? OrganizacaoId { get; set; }

        [ForeignKey("OrganizacaoId")]
        public virtual Organizacao Organizacao { get; set; }
    }
}