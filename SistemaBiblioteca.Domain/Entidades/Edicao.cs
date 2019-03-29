using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Domain.Entidades
{
    [Table("Edicao", Schema = "dbo")]
    public class Edicao : EntidadeBase
    {
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }
        [DisplayName("Preço")]
        [Required]
        public decimal Preco { get; set; }
        [DisplayName("Ano Publicação")]
        [Required]
        public int AnoPublicacao { get; set; }
        [DisplayName("Quantidade de Páginas")]
        [Required]
        public int QuantidadePagina { get; set; }
        [DisplayName("Quantidade em Estoque")]
        public int QuantidadeEstoque { get; set; }

        // relacionamentos
        [ForeignKey("Editora")]
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }

        [ForeignKey("Livro")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
