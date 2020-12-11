using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using TemplateMaterialDesignAdmin.Models.Login.Login;

namespace TemplateMaterialDesignAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AuthenticationApiClient _client;

        public LoginController(IConfiguration configuration, AuthenticationApiClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoginController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _client.GetTokenAsync(new ResourceOwnerTokenRequest
                    {
                        ClientId = _configuration["Auth0:ClientId"],
                        ClientSecret = _configuration["Auth0:ClientSecret"],
                        Scope = "openid profile",
                        Realm = "Username-Password-Authentication", // Specify the correct name of your DB connection
                        Username = vm.EmailAddress,
                        Password = vm.Password
                    });

                    // Get user info from token
                    var user = await _client.GetUserInfoAsync(result.AccessToken);

                    // Create claims principal
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId),
                        new Claim(ClaimTypes.Name, user.FullName)

                    }, CookieAuthenticationDefaults.AuthenticationScheme));

                    // Sign user into cookie middleware
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Login", vm);
                }
            }

            return RedirectToAction("Index", "Login", vm);
        }

        [HttpGet]
        public async Task LoginExternal(string connection, string returnUrl = "/")
        {
            var properties = new AuthenticationProperties() { RedirectUri = returnUrl };

            if (!string.IsNullOrEmpty(connection))
                properties.Items.Add("connection", connection);

            await HttpContext.ChallengeAsync("Auth0", properties);
        }

        // GET: LoginController/Logout
        public ActionResult Logout()
        {
            //await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            //{
            //    // Indicate here where Auth0 should redirect the user after a logout.
            //    // Note that the resulting absolute Uri must be whitelisted in the
            //    // **Allowed Logout URLs** settings for the client.
            //    RedirectUri = Url.Action("Index", "Login")
            //});
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/EsqueciSenha
        public ActionResult EsqueciSenha()
        {
            return View();
        }

        // POST: LoginController/EsqueciSenha
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EsqueciSenha(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}