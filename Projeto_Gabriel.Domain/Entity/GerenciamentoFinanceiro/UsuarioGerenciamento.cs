using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projeto_Gabriel.Domain.Entity.Base;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class UsuarioGerenciamento : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        public bool Ativo { get; set; } = true;

        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime? RefreshTokenTempoExpiracao { get; set; }

        // Chaves Estrangeiras
        [ForeignKey("Organizacao")]
        public int OrganizacaoId { get; set; }

        [ForeignKey("PerfilAcesso")]
        public int PerfilId { get; set; }


        // Entiy Framework Relationships
        public virtual Organizacao Organizacao { get; set; }
        public virtual PerfilAcesso PerfilAcesso { get; set; }
    }
}