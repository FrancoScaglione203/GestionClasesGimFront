using GestionClasesGimFront.Data.Base;
using GestionClasesGimFront.Data.DTOs;
using GestionClasesGimFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionClasesGimFront.Controllers
{
    public class AlumnosController : Controller
    {

        private readonly IHttpClientFactory _httpClient;

        public AlumnosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Alumnos()
        {
            return View();
        }


        public async Task<IActionResult> alumnosAddPartial([FromBody] AlumnoDto alumno)
        {
            var alumnosViewModel = new AlumnosViewModel();
            if (alumno != null)
            {
                alumnosViewModel = alumno;
                return PartialView("~/Views/Alumnos/Partial/AlumnosUpdatepartial.cshtml", alumnosViewModel);
            }
            //return PartialView("~/Views/Alumnos/Partial/AlumnosAddPartial.cshtml");
            return PartialView("~/Views/Alumnos/Partial/AlumnosAddPartial.cshtml");
        }

        public IActionResult GuardarAlumno(AlumnoDto alumno)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var alumnos = baseApi.PostToApi("Alumno/Agregar", alumno, token);
            return RedirectToAction("Alumnos", "Alumnos");
        }
    }
}
