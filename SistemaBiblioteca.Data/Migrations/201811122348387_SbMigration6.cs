namespace SistemaBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SbMigration6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LivroAutor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LivroId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.AutorId, cascadeDelete: true)
                .ForeignKey("dbo.Livro", t => t.LivroId, cascadeDelete: true)
                .Index(t => t.LivroId)
                .Index(t => t.AutorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LivroAutor", "LivroId", "dbo.Livro");
            DropForeignKey("dbo.LivroAutor", "AutorId", "dbo.Autor");
            DropIndex("dbo.LivroAutor", new[] { "AutorId" });
            DropIndex("dbo.LivroAutor", new[] { "LivroId" });
            DropTable("dbo.LivroAutor");
        }
    }
}
