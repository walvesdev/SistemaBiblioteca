using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Domain.Entidades
{
    [Table("Editora", Schema = "dbo")]
    public class Editora : EntidadeBase
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [DisplayName("Razão Social")]
        [Required]
        [StringLength(100)]
        public string RazaoSocial { get; set; }
        [Required]
        [StringLength(16)]
        public string CNPJ { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public List<Edicao> Edicoes { get; set; }
    }
}
