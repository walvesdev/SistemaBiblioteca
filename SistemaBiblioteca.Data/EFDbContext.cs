using SistemaBiblioteca.Domain.Entidades;
using System.Data.Entity;

namespace SistemaBiblioteca.Data
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("SistemaBiblioteca") { }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Edicao> Edicao { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public DbSet<LivroGenero> LivroGenero { get; set; }
    }
}
