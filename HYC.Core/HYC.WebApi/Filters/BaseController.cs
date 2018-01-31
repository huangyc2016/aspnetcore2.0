using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HYC.WebApi.Filters
{
    public class BaseController : Controller
    { 
        // GET: /<controller>/
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            base.OnActionExecuting(context);
        }

        /// <summary>
        /// model状态错误信息
        /// </summary>
        /// <returns></returns>
        public string GetModelStateError()
        {
            List<string> errorlist = new List<string>();
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    errorlist.Add(item.Errors[0].ErrorMessage);
                }
            }
            return string.Join(";", errorlist);
        }
    }
}
