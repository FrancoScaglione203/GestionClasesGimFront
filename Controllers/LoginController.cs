using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using GestionClasesGimFront.Data.DTOs;

namespace GestionClasesGimFront.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            //var baseApi = new BaseApi(_httpClient);
            //var token = await baseApi.PostToApi("Login", login);
            //var resultadoLogin = token as OkObjectResult;
            //var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoginResponse>>(resultadoLogin.Value.ToString());

            //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            //Claim claimRole = new(ClaimTypes.Role, apiResponse.Data.roleId.ToString());

            //identity.AddClaim(claimRole);

            //var claimPrincipal = new ClaimsPrincipal(identity);

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties
            //{
            //    ExpiresUtc = DateTime.Now.AddHours(1),
            //});

            //HttpContext.Session.SetString("Token", apiResponse.Data.Token);

            //var homeViewModel = new HomeViewModel();
            //homeViewModel.Token = apiResponse.Data.Token;

            //return View("~/Views/Home/Index.cshtml", homeViewModel);
            return View("~/Views/Home/Index.cshtml");

        }
    }
}
