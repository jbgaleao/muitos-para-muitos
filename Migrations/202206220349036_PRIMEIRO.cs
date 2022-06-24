namespace muitos_para_muitos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PRIMEIRO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        DisciplinaId = c.Int(nullable: false, identity: true),
                        CodigoDisciplina = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DisciplinaId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        CargaHoraria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfessorId);
            
            CreateTable(
                "dbo.ProfessorDisciplinas",
                c => new
                    {
                        Professor_ProfessorId = c.Int(nullable: false),
                        Disciplina_DisciplinaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_ProfessorId, t.Disciplina_DisciplinaId })
                .ForeignKey("dbo.Professors", t => t.Professor_ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_DisciplinaId, cascadeDelete: true)
                .Index(t => t.Professor_ProfessorId)
                .Index(t => t.Disciplina_DisciplinaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfessorDisciplinas", "Disciplina_DisciplinaId", "dbo.Disciplinas");
            DropForeignKey("dbo.ProfessorDisciplinas", "Professor_ProfessorId", "dbo.Professors");
            DropIndex("dbo.ProfessorDisciplinas", new[] { "Disciplina_DisciplinaId" });
            DropIndex("dbo.ProfessorDisciplinas", new[] { "Professor_ProfessorId" });
            DropTable("dbo.ProfessorDisciplinas");
            DropTable("dbo.Professors");
            DropTable("dbo.Disciplinas");
        }
    }
}
