using SistemaBiblioteca.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Domain.VO
{
    public class PaginacaoEntidadeVO<TEntity>
        where TEntity : EntidadeBase
    {
        public List<TEntity> Lista { get; set; }
        public int QuantidadeRegistros { get; set; }
        public int PaginaAtual { get; set; }
        public int ItensPorPagina { get; set; }

        public int QuantidadePaginas
        {
            get
            {
                if (QuantidadeRegistros == 0) return 0;

                return (int)Math
                    .Ceiling(QuantidadeRegistros / (decimal)ItensPorPagina);
            }
        }
    }
}
