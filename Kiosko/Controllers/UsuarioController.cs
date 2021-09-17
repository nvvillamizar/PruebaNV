using KioskoEntidad;
using KioskoNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Kiosko.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioNeg UsuarioNegocio = new UsuarioNeg();

        public IActionResult Index()
        {
            return View(UsuarioNegocio.Listar());
        }

        public IActionResult Edit(int Id = 0)
        {
            ViewData["Titulo"] = Id == 0 ? "Crear" : "Editar";
            return View(Id == 0 ? new UsuariosEnt() : UsuarioNegocio.Obtener(Id));
        }

        public IActionResult Update(UsuariosEnt usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                UsuarioNegocio.Registrar(usuario);
            }
            else
            {
                UsuarioNegocio.Actualizar(usuario);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            UsuarioNegocio.Eliminar(Id);
            return RedirectToAction("Index");
        }
    }
}
