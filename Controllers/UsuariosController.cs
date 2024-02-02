using GestionClasesGimFront.Data.Base;
using GestionClasesGimFront.Data.DTOs;
using GestionClasesGimFront.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace GestionClasesGimFront.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public UsuariosController(IHttpClientFactory httpClient) 
        {
            _httpClient = httpClient;
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public async Task<IActionResult> usuariosAddPartial() 
        {
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml");
        }

        public IActionResult GuardarUsuario(UsuarioDto usuario)
        {
            //var baseApi = new BaseApi(_httpClient);
            //var token = await baseApi.PostToApi("Login", login); //Llama al EndPoint del back y envia lo que tiene que recibir ese endpoint
            //var resultadoLogin = token as OkObjectResult;


            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.PostToApi("Usuario/Agregar", usuario, token);
            //return View("~/Views/Usuarios/Usuarios.cshtml");
            return RedirectToAction("Usuarios", "Usuarios");
        }
    }
}
