using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HYC.WebApi.Filters;
using HYC.Model.Response;
using HYC.Model.Users;
using Microsoft.AspNetCore.Cors;
using HYC.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HYC.WebApi.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [Produces("application/json")]
    public class HomeController : BaseController
    {
        private IUserService _userTodo { get; set; }
        public HomeController(IUserService userTodo)
        {
            this._userTodo = userTodo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Redirect("/swagger/index.html");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpGet("Home/Add")]
        public ResponseData Add()
        {
            UserInfo user = new UserInfo() { UserName = "huangyc", Password = "123456", EMail = "281010937@qq.com" };
            int r = this._userTodo.Insert(user);
            var resData = new ResponseData();
            resData.code = 0;
            resData.msg = "登录成功";
            resData.body = r;
            return resData;
        }

        /// <summary>
        /// 登录验证9092
        /// </summary>
        /// <param name="inParam">接收对象</param>
        /// <remarks>code=0 登录成功，code=1帐号密码错误，code=2 登录失败, code=3 帐号停用 ，code=4 IP验证不通过</remarks>
        /// <returns>ResponseData</returns>
        [HttpPost("Home/Login")]
        [ProducesResponseType(typeof(ResponseDataProduces<Login>), 200)]
        public ResponseData Login([FromBody]LoginInParam inParam)
        {
            if (string.IsNullOrEmpty(inParam.UserName) || string.IsNullOrEmpty(inParam.Password))
            {
                return new ResponseData()
                {
                    code = (int)ErrorCodeEnum.参数错误,
                    msg = "帐号名密码不能为空"
                };
            }
            var resData = new ResponseData();
            resData.code = 0;
            resData.msg = "登录成功";
            resData.body = new Login()
            {
                UserID = 1,
                Token = "abcdefg",
                UserName = "huangyc",
            };
            return resData;
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <remarks>code=0 登出成功</remarks>
        /// <returns>ResponseData</returns>
        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("Home/GetUserList")]
        public ResponseData GetUserList()
        {
            List<UserInfo> list = new List<UserInfo>();
            list.Add(new UserInfo() { UserName = "huangyc1", EMail = "281010937@qq.com" });
            list.Add(new UserInfo() { UserName = "huangyc2", EMail = "281010937@qq.com" });
            return new ResponseData()
            {
                code = 0,
                body = new ResponseDataArray<UserInfo>() { Data = list }
            };
        }
    }
}
