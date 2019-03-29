using SistemaBiblioteca.Business;
using SistemaBiblioteca.Domain.Entidades;
using System.Web.Mvc;

namespace SistemaBibliotecaMVC.Controllers
{
    public class LivroGeneroController : Controller
    {
        // GET: LivroGenero
        public ActionResult Index(string nome, int? paginaAtual, int? qtdeLinhas)
        {
            ViewBag.Title = "Livro Gênero";

            // filtro de pesquisa
            nome = nome ?? string.Empty;
            ViewBag.Nome = nome;

            // configurar página
            qtdeLinhas = qtdeLinhas ?? 10;
            paginaAtual = paginaAtual ?? 0;

            var lista = FacadeBS
                .LivroGenero
                    .Pesquisar(
                        x => x.Nome.Contains(nome)
                        , (int)paginaAtual
                        , (int)qtdeLinhas
                    );

            return View(lista);
        }

        // GET: LivroGenero/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Detalhes Livro Gênero";
            // LivroGenero item = banco.LivroGenero.Find(id);
            LivroGenero item = FacadeBS
                .LivroGenero
                    .PesquisarPorId((int)id);
            return View(item);
        }

        // GET: LivroGenero/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Novo Livro Gênero";
            return View();
        }

        // POST: LivroGenero/Create
        [HttpPost]
        public ActionResult Create(LivroGenero livroGenero)
        {
            ViewBag.Title = "Novo Livro Gênero";

            if (!ModelState.IsValid)
            {
                return View();
            }

            // banco.LivroGenero.Add(livroGenero);
            // banco.SaveChanges();
            FacadeBS.LivroGenero.Adicionar(livroGenero);
            return RedirectToAction("Index");
        }

        // GET: LivroGenero/Editar/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Editar Livro Gênero";
            // LivroGenero item = banco.LivroGenero.Find(id);
            LivroGenero item = FacadeBS
                .LivroGenero
                    .PesquisarPorId((int)id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, LivroGenero livroGenero)
        {
            ViewBag.Title = "Editar Livro Gênero";

            if (!ModelState.IsValid)
            {
                return View(livroGenero);
            }

            // LivroGenero livroGeneroBanco = banco.LivroGenero.Find(id);
            LivroGenero livroGeneroBanco = FacadeBS
                .LivroGenero
                    .PesquisarPorId((int)id);
            livroGeneroBanco.Nome = livroGenero.Nome;
            // banco.SaveChanges();
            FacadeBS.LivroGenero.Alterar(livroGeneroBanco);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            //LivroGenero livroGenero = banco.LivroGenero.Find(id);
            //banco.LivroGenero.Remove(livroGenero);
            //banco.SaveChanges();
            LivroGenero livroGenero = FacadeBS
                .LivroGenero
                    .PesquisarPorId((int)id);
            FacadeBS.LivroGenero.Excluir(livroGenero);
            return RedirectToAction("Index");
        }

    }
}