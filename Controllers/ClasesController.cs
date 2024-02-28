using GestionClasesGimFront.Data.Base;
using GestionClasesGimFront.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace GestionClasesGimFront.Controllers
{
    public class ClasesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public ClasesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Clases()
        {
            return View();
        }

        public IActionResult Inscripcion(int idClase, int dniAlumno)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            string dniA = dniAlumno.ToString();
            string idC= idClase.ToString();
            var clase = baseApi.PutToApi($"Clase/Inscripcion?idClase={idC}&dniAlumno={dniA}",1, token);
            return View("Clases", "Clases");
        }

        public IActionResult Cancelacion(int idClase, int dniAlumno)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            string dniA = dniAlumno.ToString();
            string idC = idClase.ToString();
            var clase = baseApi.PutToApi($"Clase/Cancelacion?idClase={idC}&dniAlumno={dniA}", 1, token);
            return View("Clases", "Clases");
        }
    }
}
