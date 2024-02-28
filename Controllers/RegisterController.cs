using GestionClasesGimFront.Data.Base;
using GestionClasesGimFront.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace GestionClasesGimFront.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public RegisterController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult GuardarAlumno(AlumnoDto alumno)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var alumnos = baseApi.PostToApi("Alumno/Agregar", alumno, token);
            return RedirectToAction("Login", "Login");
        }
    }
}
