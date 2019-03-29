using SistemaBiblioteca.Business;
using SistemaBiblioteca.Domain.Entidades;
using System.Web.Mvc;

namespace SistemaBibliotecaMVC.Controllers
{
    public class EditoraController : Controller
    {
        // GET: Editora
        public ActionResult Index(int? paginaAtual, int? itensPorPagina)
        {
            // configurar página
            itensPorPagina = itensPorPagina ?? 10;
            paginaAtual = paginaAtual ?? 0;

            return View(FacadeBS.
                Editora.
                    Listar((int)paginaAtual, (int)itensPorPagina));
        }

        // GET: Editora/Details/5
        public ActionResult Details(int id)
        {
            return View(FacadeBS.Editora.PesquisarPorId(id));
        }

        // GET: Editora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editora/Create
        [HttpPost]
        public ActionResult Create(Editora model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                FacadeBS.Editora.Adicionar(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Editora/Edit/5
        public ActionResult Edit(int id)
        {
            return View(FacadeBS.Editora.PesquisarPorId(id));
        }

        // POST: Editora/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Editora model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                FacadeBS.Editora.Alterar(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Editora/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FacadeBS.Editora.PesquisarPorId(id));
        }

        // POST: Editora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                FacadeBS.Editora.Excluir(e => e.Id == id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
