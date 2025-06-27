using Projeto_Gabriel.Domain.Entity.Base;
using Projeto_Gabriel.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Gabriel.Domain.Entity.GerenciamentoFinanceiro
{
    public class PerfilAcesso : BaseEntity
    {
        [Required]
        public NomeCargosAcesso Nome { get; set; }

        public string Descricao { get; set; }


        // Entity Framework Relationships
        public virtual ICollection<UsuarioGerenciamento> Usuarios { get; set; } = new List<UsuarioGerenciamento>();
    }
}