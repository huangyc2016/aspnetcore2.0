using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HYC.WebAdmin.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using HYC.IRepository;

namespace HYC.WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _userTodo { get; set; }
        public HomeController(IUserRepository userTodo)
        {
            this._userTodo = userTodo;
        }

        /// <summary>
        /// 该Action判断用户是否已经登录，如果已经登录，那么读取登录用户的用户名
        /// </summary>
        public IActionResult Index()
        {
            //如果HttpContext.User.Identity.IsAuthenticated为true，
            //或者HttpContext.User.Claims.Count()大于0表示用户已经登录
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                //这里通过 HttpContext.User.Claims 可以将我们在Login这个Action中存储到cookie中的所有
                //claims键值对都读出来，比如我们刚才定义的UserName的值Wangdacui就在这里读取出来了
                var userName = HttpContext.User.Claims.First().Value;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 该Action登录用户Wangdacui到Asp.Net Core
        /// </summary>
        public IActionResult Login(string userName, string password)
        {
            var Value = "0";

            var login = _userTodo.Login(userName, password);
            if (login != null)
            {
                //下面的变量claims是Claim类型的数组，Claim是string类型的键值对，所以claims数组中可以存储任意个和用户有关的信息，
                //不过要注意这些信息都是加密后存储在客户端浏览器cookie中的，所以最好不要存储太多特别敏感的信息，这里我们只存储了用户名到claims数组,
                //表示当前登录的用户是谁
                var claims = new[] {
                    new Claim(ClaimTypes.Name, "huangyc"),
                    new Claim("LastChanged", Value)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);
                //登录用户，相当于ASP.NET中的FormsAuthentication.SetAuthCookie
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user).Wait();
                //可以使用HttpContext.SignInAsync方法的重载来定义持久化cookie存储用户认证信息，例如下面的代码就定义了用户登录后60分钟内cookie都会保留在客户端计算机硬盘上，
                //即便用户关闭了浏览器，60分钟内再次访问站点仍然是处于登录状态，除非调用Logout方法注销登录。

                /*HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                user, new AuthenticationProperties() { IsPersistent = true, ExpiresUtc = DateTimeOffset.Now.AddMinutes(60) }).Wait();
                */

                return View("/Index");
            }
            else
            {
                return View("/Index");
            }
        }

        /// <summary>
        /// 该Action从Asp.Net Core中注销登录的用户
        /// </summary>
        public IActionResult Logout()
        {
            //注销登录的用户，相当于ASP.NET中的FormsAuthentication.SignOut
            HttpContext.SignOutAsync().Wait();
            var name = HttpContext.User.Claims.First().Value;
            HttpContext.SignOutAsync(name).Wait();
            return View();
        }
    }
}
