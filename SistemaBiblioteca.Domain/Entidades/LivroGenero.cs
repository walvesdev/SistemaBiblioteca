using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Domain.Entidades
{
    [Table("LivroGenero", Schema = "dbo")]
    public class LivroGenero : EntidadeBase
    {
        [DisplayName("Nome Gênero")]
        [Required]
        [StringLength(100, ErrorMessage = "Limite máximo de caracteres é 100.")]
        public string Nome { get; set; }

        public List<Livro> Livros { get; set; }
    }
}
