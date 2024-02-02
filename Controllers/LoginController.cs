using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using GestionClasesGimFront.Data.DTOs;
using GestionClasesGimFront.Data.Base;
using Newtonsoft.Json;
using GestionClasesGimFront.Models;
using System.Net;
using GestionClasesGimFront.ViewModels;

namespace GestionClasesGimFront.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public LoginController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            var baseApi = new BaseApi(_httpClient);
            var token = await baseApi.PostToApi("Login", login); //Llama al EndPoint del back y envia lo que tiene que recibir ese endpoint
            var resultadoLogin = token as OkObjectResult;
            var apiResponse = JsonConvert.DeserializeObject<LoginResponse>(resultadoLogin.Value.ToString());

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            Claim claimRole = new(ClaimTypes.Role, apiResponse.roleId.ToString());
            Claim claimDni = new Claim("Dni", apiResponse.Dni.ToString());


            identity.AddClaim(claimRole);
            identity.AddClaim(claimDni);

            var claimPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(1), //Tiempo que se mantiene la sesion
            });

            

            //var homeViewModel = new HomeViewModel();
            //homeViewModel.Token = apiResponse.Token;   

            

            string Dni = apiResponse.Dni.ToString();
            string Token = apiResponse.Token.ToString();
            HttpContext.Session.SetString("Dni", Dni);
            HttpContext.Session.SetString("Token", Token);

            return RedirectToAction("Index", "Home");
            //return View("~/Views/Home/Index.cshtml", homeViewModel);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
