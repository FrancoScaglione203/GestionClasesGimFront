using GestionClasesGimFront.Data.Base;
using GestionClasesGimFront.Data.DTOs;
using GestionClasesGimFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace GestionClasesGimFront.Controllers
{
    public class ClasesAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public ClasesAdminController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult ClasesAdmin()
        {
            return View();
        }


        public IActionResult GuardarClase(ClaseDto clase)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var alumnos = baseApi.PostToApi("Clase/Agregar", clase, token);
            return RedirectToAction("Home", "Index");
        }
        public IActionResult alumnosClasePartial([FromQuery]int claseId)
        {
            HttpContext.Session.SetString("idClase", claseId.ToString());
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var response = baseApi.getFromApi($"Clase/ClaseById?claseId={claseId.ToString()}", token).Result;

            if (response is OkObjectResult okResult)
            {
                var json = okResult.Value.ToString();
                var clase = JsonConvert.DeserializeObject<ClaseDto>(json);

                var clasesViewModel = new ClasesViewModel
                {
                    Nombre = clase.Nombre,
                    FechaHorario = clase.FechaHorario,
                    Cupos = clase.Cupos,
                    CapacidadMax = clase.CapacidadMax,
                    imagenUrl = clase.imagenUrl,
                    Activo = clase.Activo

                };

                return View("~/Views/ClasesAdmin/Partial/AlumnosClasePartial.cshtml", clasesViewModel);
            }
            return View("~/Views/ClasesAdmin/Partial/AlumnosClasePartial.cshtml");
        }
    }
}
