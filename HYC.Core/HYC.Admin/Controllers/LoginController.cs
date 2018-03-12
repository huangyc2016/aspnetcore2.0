using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HYC.IRepository;
using HYC.Admin.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using HYC.Model.Users;
using Newtonsoft.Json;
using HYC.Model.Permission;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HYC.Admin.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userTodo { get; set; }
        private IPermissionRepository _permissionToDo { get; set; }
        public LoginController(IUserRepository userTodo, IPermissionRepository permissionToDo)
        {
            this._userTodo = userTodo;
            this._permissionToDo = permissionToDo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //检查用户信息
                var userdata = _userTodo.Login(model.UserName, model.Password);
                if (userdata != null)
                {
                    //获取用户拥有的功能信息
                    var actiondata = this._permissionToDo.GetActionAuthorizesList(userdata.Id);

                    //记录cookie
                    WriteUser(userdata, actiondata);
                    //跳转到系统首页
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = "用户名或密码错误。";
                return View();
            }
            ViewBag.ErrorInfo = ModelState.Values.First().Errors[0].ErrorMessage;

            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);   // Startup.cs中配置的验证方案名
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Forbidden()
        {
            return View();
        }


        private async void WriteUser(UserData userdata,List<ActionAuthorizes> actiondata)
        {
            string struserdata = JsonConvert.SerializeObject(userdata);
            string stractionsdata = JsonConvert.SerializeObject(actiondata);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userdata.UserName,ClaimValueTypes.String, issuer:"http://contoso.com"),
                new Claim(ClaimTypes.UserData,struserdata,ClaimValueTypes.String, issuer:"http://contoso.com"),
                new Claim("ActionData",stractionsdata,ClaimValueTypes.String,issuer:"http://contoso.com"),
                new Claim("LastChanged", userdata.LastChanged.ToString("yyyy-MM-dd HH:mm:ss:fff"),ClaimValueTypes.String, issuer:"http://contoso.com")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               new AuthenticationProperties
               {
                   ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                   IsPersistent = true,
                   //AllowRefresh = true
               });
        }
    }
}
