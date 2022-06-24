using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace muitos_para_muitos.Models
{
    public class Professor
    {

        public Professor()
        {
            this.Disciplinas = new HashSet<Disciplina>().ToList();
        }

        [Key]
        public int ProfessorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [Range(20,40)]
        [Display(Name="Carga Horária")]
        public int CargaHoraria{ get; set; }

        public List<Disciplina> Disciplinas { get; set; }
    }
}