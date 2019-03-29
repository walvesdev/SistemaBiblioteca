using SistemaBiblioteca.Domain.Entidades;
using SistemaBiblioteca.Domain.VO;
using SistemaBibliotecaMVC.Models;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaBibliotecaMVC.Helpers
{
    public static class PaginacaoHelper
    {
        public static MvcHtmlString Paginacao<TEntity>(this HtmlHelper htmlHelper
            , PaginacaoEntidadeVO<TEntity> paginacaoModel)
            where TEntity : EntidadeBase
        {
            return Paginacao(
                htmlHelper
                , paginacaoModel
                , new RouteValueDictionary());
        }


        public static MvcHtmlString Paginacao<TEntity>(this HtmlHelper htmlHelper
            , PaginacaoEntidadeVO<TEntity> paginacaoModel
            , dynamic Filtros)
            where TEntity : EntidadeBase
        {
            return Paginacao(
                htmlHelper
                , paginacaoModel.PaginaAtual
                , paginacaoModel.QuantidadePaginas
                , paginacaoModel.ItensPorPagina
                , paginacaoModel.QuantidadeRegistros
                , Filtros);
        }

        public static MvcHtmlString Paginacao(this HtmlHelper htmlHelper
            , int PaginaAtual
            , int QtdePaginas
            , int QtdeLinhas
            , int QtdeRegistros
            , dynamic Filtros)
        {
            // obtém URL Helper
            var request = HttpContext.Current.Request.RequestContext;
            var urlHelper = new UrlHelper(request);

            var sb = new StringBuilder();

            sb.Append("<div class=\"row\">");

            // bloco alterar quantidade de itens e página
            sb.Append("<div class=\"col-lg-6\">");
            sb.Append("Página");
            sb.Append("<select onchange=\"carregarUrl(this)\">");

            for (int i = 0; i < QtdePaginas; i++)
            {
                var filtro = new RouteValueDictionary(Filtros);
                filtro.Add("paginaAtual", i);
                filtro.Add("qtdeLinhas", QtdeLinhas);

                string url = urlHelper.Action("Index", filtro);
                string texto = (i + 1).ToString();
                string selecionado = PaginaAtual == i ? "selected" : "";

                sb.Append(
                    string.Format(
                        "<option value=\"{0}\" {1}>{2}</option>"
                            , url, selecionado, texto
                    )
                );
            }

            sb.Append("</select>");
            sb.Append("de " + QtdePaginas + " - Itens por página");

            sb.Append("<select onchange=\"carregarUrl(this)\">");

            for (int i = 5; i <= 50; i += 5)
            {
                var filtro = new RouteValueDictionary(Filtros);
                filtro.Add("paginaAtual", 0);
                filtro.Add("qtdeLinhas", i);

                string url = urlHelper.Action("Index", filtro);
                string texto = i.ToString();
                string selecionado = QtdeLinhas == i ? "selected" : "";

                sb.Append(
                    string.Format(
                        "<option value=\"{0}\" {1}>{2}</option>"
                            , url, selecionado, texto
                    )
                );
            }

            sb.Append("</select>");
            sb.Append("</div>");

            // quantidade de registros encontrados
            sb.Append("<div class=\"col-lg-6 text-right\">");

            sb.Append(QtdeRegistros + " registro(s) encontrado(s)");

            sb.Append("</div>");
            sb.Append("</div>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}