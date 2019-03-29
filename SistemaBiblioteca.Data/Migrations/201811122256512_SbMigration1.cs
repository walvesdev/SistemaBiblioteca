namespace SistemaBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SbMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Autor", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Autor", "CPF", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Autor", "Pseudonimo", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Autor", "Telefone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Autor", "Pais", c => c.String(maxLength: 60));
            AlterColumn("dbo.Autor", "Bibliografia", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Edicao", "ISBN", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Editora", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Editora", "RazaoSocial", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Editora", "CNPJ", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Livro", "Titulo", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Livro", "Idioma", c => c.String(maxLength: 5));
            AlterColumn("dbo.LivroGenero", "Nome", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LivroGenero", "Nome", c => c.String());
            AlterColumn("dbo.Livro", "Idioma", c => c.String());
            AlterColumn("dbo.Livro", "Titulo", c => c.String());
            AlterColumn("dbo.Editora", "CNPJ", c => c.String());
            AlterColumn("dbo.Editora", "RazaoSocial", c => c.String());
            AlterColumn("dbo.Editora", "Nome", c => c.String());
            AlterColumn("dbo.Edicao", "ISBN", c => c.String());
            AlterColumn("dbo.Autor", "Bibliografia", c => c.String());
            AlterColumn("dbo.Autor", "Pais", c => c.String());
            AlterColumn("dbo.Autor", "Telefone", c => c.String());
            AlterColumn("dbo.Autor", "Pseudonimo", c => c.String());
            AlterColumn("dbo.Autor", "CPF", c => c.String());
            AlterColumn("dbo.Autor", "Nome", c => c.String());
        }
    }
}
