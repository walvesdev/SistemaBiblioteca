using SistemaBiblioteca.Business;
using SistemaBiblioteca.Domain.Entidades;
using System.Web.Mvc;

namespace SistemaBibliotecaMVC.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index(int? paginaAtual, int? itensPorPagina)
        {
            // configurar página
            itensPorPagina = itensPorPagina ?? 10;
            paginaAtual = paginaAtual ?? 0;

            return View(FacadeBS.
                Autor.
                    Listar((int)paginaAtual, (int)itensPorPagina));
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            return View(FacadeBS.Autor.PesquisarPorId(id));
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(Autor model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();
                }

                FacadeBS.Autor.Adicionar(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            return View(FacadeBS.Autor.PesquisarPorId(id));
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Autor model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();
                }

                FacadeBS.Autor.Alterar(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FacadeBS.Autor.PesquisarPorId(id));
        }

        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Autor model)
        {
            try
            {
                FacadeBS.Autor.Excluir(e => e.Id == id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
