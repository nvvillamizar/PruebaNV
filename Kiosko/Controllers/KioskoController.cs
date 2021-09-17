using KioskoEntidad;
using KioskoNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Kiosko.Controllers
{
    public class KioskoController : Controller
    {
        private KioskoNeg KioskoNegocio = new KioskoNeg();
        private UsuarioNeg UsuarioNegocio = new UsuarioNeg();

        public IActionResult Index()
        {
            return View(KioskoNegocio.Listar());
        }

        public IActionResult Edit(int Id = 0)
        {
            ViewBag.Usuario = UsuarioNegocio.Listar();
            ViewBag.Estados = KioskoNegocio.listaEstadoKiosko();
            ViewData["Titulo"] = Id == 0 ? "Crear" : "Editar";
            return View(Id == 0 ? new KioskoEnt() : KioskoNegocio.Obtener(Id));
        }

        public IActionResult Update(KioskoEnt kiosko)
        {
            if (kiosko.Id == 0)
            {
                KioskoNegocio.Registrar(kiosko);
            }
            else
            {
                KioskoNegocio.Actualizar(kiosko);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            KioskoNegocio.Eliminar(Id);
            return RedirectToAction("Index");
        }
    }
}
