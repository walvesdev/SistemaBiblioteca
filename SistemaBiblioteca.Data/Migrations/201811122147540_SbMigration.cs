namespace SistemaBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SbMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        Pseudonimo = c.String(),
                        Telefone = c.String(),
                        AnoNascimento = c.Int(nullable: false),
                        Pais = c.String(),
                        Bibliografia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Edicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AnoPublicacao = c.Int(nullable: false),
                        QuantidadePagina = c.Int(nullable: false),
                        QuantidadeEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        RazaoSocial = c.String(),
                        CNPJ = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Idioma = c.String(),
                        AnoLancamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LivroGenero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LivroGenero");
            DropTable("dbo.Livro");
            DropTable("dbo.Editora");
            DropTable("dbo.Edicao");
            DropTable("dbo.Autor");
        }
    }
}
