using Microsoft.AspNetCore.Mvc;

namespace GestionClasesGimFront.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Usuarios()
        {
            return View();
        }
    }
}
