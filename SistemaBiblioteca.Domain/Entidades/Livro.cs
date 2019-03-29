using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Domain.Entidades
{
    [Table("Livro", Schema = "dbo")]
    public class Livro : EntidadeBase
    {
        [DisplayName("Título")]
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }
        [StringLength(5)]
        public string Idioma { get; set; }
        [DisplayName("Ano Lançamento")]
        [Required]
        public int AnoLancamento { get; set; }

        // Relacionamentos
        [ForeignKey("LivroGenero")]
        public int LivroGeneroId { get; set; }
        public LivroGenero LivroGenero { get; set; }

        public List<Edicao> Edicoes { get; set; }
        public List<LivroAutor> LivroAutor { get; set; }
    }
}
