using muitos_para_muitos.Models;

using System.Data.Entity;

namespace muitos_para_muitos.Contexto
{
    public class Context : DbContext
    {
        public Context():  base("Teste")
        {

        }

        public DbSet<Professor> PROFESSORES { get; set; }
        public DbSet<Disciplina> DISCIPLINAS { get; set; }

    }
}