using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace muitos_para_muitos.Models
{
    public class Disciplina
    {
        [Key]
        public int DisciplinaId { get; set; }
        [Required]
        public int CodigoDisciplina { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        public ICollection<Professor> Professores { get; set; }
    }
}