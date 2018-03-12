using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HYC.WebAdmin.Models;
using HYC.IRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HYC.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userTodo { get; set; }
        public LoginController(IUserRepository userTodo)
        {
            this._userTodo = userTodo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    //检查用户信息
            //    var user = _userTodo.CheckUser(model.UserName, model.Password);
            //    if (user != null)
            //    {
            //        //记录Session
            //        /////HttpContext.Session.Set("CurrentUser", Utility.ByteConvertHelper.ObjectToBytes(user));

            //        //记录cookie
            //        WriteUser(4, model.UserName, model.Password);
            //        //跳转到系统首页
            //        return RedirectToAction("Index", "Home");
            //    }
            //    ViewBag.ErrorInfo = "用户名或密码错误。";
            //    return View();
            //}
            //ViewBag.ErrorInfo = ModelState.Values.First().Errors[0].ErrorMessage;

            return View(model);
        }
    }
}
