using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Domain.Entidades
{
    [Table("Autor", Schema = "dbo")]
    public class Autor : EntidadeBase
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string CPF { get; set; }
        [DisplayName("Pseudônimo")]
        [Required]
        [StringLength(20)]
        public string Pseudonimo { get; set; }
        [StringLength(11)]
        public string Telefone { get; set; }
        [DisplayName("Ano Nascimento")]
        public int AnoNascimento { get; set; }
        [DisplayName("País")]
        [StringLength(60)]
        public string Pais { get; set; }
        [StringLength(2000)]
        public string Bibliografia { get; set; }

        public List<LivroAutor> LivroAutor { get; set; }
    }
}
