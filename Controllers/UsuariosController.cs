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

        public async Task<IActionResult> usuariosAddPartial([FromBody] UsuarioDto usuario) 
        {
            var usuariosViewModel = new UsuariosViewModel();
            if (usuario != null)
            {
                usuariosViewModel = usuario;
                return PartialView("~/Views/Usuarios/Partial/UsuariosUpdatepartial.cshtml",usuariosViewModel);
            }
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml");
        }



        public async Task<IActionResult> usuariosDeletePartial([FromBody] UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel = usuario;
            return PartialView("~/Views/Usuarios/Partial/UsuariosDeletePartial.cshtml",usuariosViewModel);
        }


        public IActionResult GuardarUsuario(UsuarioDto usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.PostToApi("Usuario/Agregar", usuario, token);
            return RedirectToAction("Usuarios", "Usuarios");
        }

        public IActionResult EditarUsuario(UsuarioDto usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            string dni = usuario.Dni.ToString();
            var usuarios = baseApi.PutToApi($"Usuario/Editar?dni={dni}", usuario, token);
            return RedirectToAction("Usuarios", "Usuarios");
        }

        public IActionResult EliminarUsuario(UsuarioDto usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            string dni = usuario.Dni.ToString();
            var usuarios = baseApi.PutToApi($"Usuario/DeleteLogico?dni={dni}", usuario, token);
            return RedirectToAction("Usuarios", "Usuarios");
        }
    }
}
