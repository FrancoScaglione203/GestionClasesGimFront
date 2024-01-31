using Microsoft.AspNetCore.Mvc;

namespace GestionClasesGimFront.Controllers
{
    public class AlumnosController : Controller
    {
        public IActionResult Alumnos()
        {
            return View();
        }
    }
}
