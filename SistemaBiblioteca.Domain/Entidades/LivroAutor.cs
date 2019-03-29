using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Domain.Entidades
{
    [Table("LivroAutor", Schema = "dbo")]
    public class LivroAutor : EntidadeBase
    {
        [ForeignKey("Livro")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
