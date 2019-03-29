namespace SistemaBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SbMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livro", "LivroGeneroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Livro", "LivroGeneroId");
            AddForeignKey("dbo.Livro", "LivroGeneroId", "dbo.LivroGenero", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "LivroGeneroId", "dbo.LivroGenero");
            DropIndex("dbo.Livro", new[] { "LivroGeneroId" });
            DropColumn("dbo.Livro", "LivroGeneroId");
        }
    }
}
