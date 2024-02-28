using GestionClasesGimFront.Data.DTOs;
using GestionClasesGimFront.Data.Base;
using GestionClasesGimFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionClasesGimFront.Controllers
{
    public class PerfilController : Controller
    {
        //public IActionResult Perfil()
        //{

        //    return View();
        //}

        private readonly IHttpClientFactory _httpClient;

        public PerfilController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }


        public IActionResult GuardarAlumno(AlumnoDto alumno)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            string dniA = alumno.Dni.ToString();
            var clase = baseApi.PutToApi($"Alumno/EditarByDni?dni={dniA}", alumno, token);
            return View("Perfil", "Perfil");
        }

        public async Task<IActionResult> Perfil()
        {
            var token = HttpContext.Session.GetString("Token");
            var dni = HttpContext.Session.GetString("Dni");
            var baseApi = new BaseApi(_httpClient);
            string dniA = dni.ToString();

            // Llamar a la función getFromApi para obtener los datos del alumno
            var response = baseApi.getFromApi($"Alumno/AlumnoByDni?dni={dniA}", token).Result;

            // Verificar si la respuesta es un OkResult (200)
            if (response is OkObjectResult okResult)
            {
                // Obtener el JSON del cuerpo de la respuesta

                // Deserializar el JSON en un objeto Alumno
                var json = okResult.Value.ToString(); // Convertir a cadena de texto
                var alumno = JsonConvert.DeserializeObject<AlumnoDto>(json);

                // Crear un objeto AlumnosViewModel y asignarle los datos del alumno

                var alumnosViewModel = new AlumnosViewModel
                {
                    Nombre = alumno.Nombre,
                    Apellido = alumno.Apellido,
                    Dni = alumno.Dni,
                    Clave = alumno.Clave,
                    RoleId = alumno.RoleId
                  
                };


                // Pasar el objeto AlumnosViewModel a la vista
                return View("~/Views/Perfil/Perfil.cshtml", alumnosViewModel);
            }
            else if (response is UnauthorizedResult)
            {
                // Manejar la autorización no válida
                return Unauthorized();
            }
            else
            {
                // Manejar otros casos de respuesta
                return BadRequest();
            }
        }
    }
}
