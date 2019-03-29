namespace SistemaBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SbMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Edicao", "EditoraId", c => c.Int(nullable: false));
            AddColumn("dbo.Edicao", "LivroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Edicao", "EditoraId");
            CreateIndex("dbo.Edicao", "LivroId");
            AddForeignKey("dbo.Edicao", "EditoraId", "dbo.Editora", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Edicao", "LivroId", "dbo.Livro", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Edicao", "LivroId", "dbo.Livro");
            DropForeignKey("dbo.Edicao", "EditoraId", "dbo.Editora");
            DropIndex("dbo.Edicao", new[] { "LivroId" });
            DropIndex("dbo.Edicao", new[] { "EditoraId" });
            DropColumn("dbo.Edicao", "LivroId");
            DropColumn("dbo.Edicao", "EditoraId");
        }
    }
}
