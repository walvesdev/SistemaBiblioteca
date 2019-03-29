using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBibliotecaMVC.Models
{
    public class PaginacaoModel<T>
    {
        public List<T> Lista { get; set; }
        public int QtdeRegistros { get; set; }
        public int PaginaAtual { get; set; }
        public int QtdeLinhas { get; set; }

        public int QtdePaginas
        {
            get
            {
                return (int)Math.Ceiling(QtdeRegistros / (decimal)QtdeLinhas);
            }
        }
    }
}