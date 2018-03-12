using HYC.IRepository;
using HYC.Model.Permission;
using HYC.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HYC.Admin.Authorization
{
    public class ActionRequirement : AuthorizationHandler<ActionRequirement>, IAuthorizationRequirement
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActionRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.UserData && c.Issuer == "http://contoso.com"))
            {
                return Task.CompletedTask;
            }
            //从cookie中获取用户信息
            var strUserData = context.User.FindFirst(c => c.Type == ClaimTypes.UserData).Value;
            var userdata = JsonConvert.DeserializeObject<UserData>(strUserData);

            var strActionData = (from c in context.User.Claims
                                   where c.Type == "ActionData"
                              select c.Value).FirstOrDefault();

            var actionData = JsonConvert.DeserializeObject<List<ActionAuthorizes>>(strActionData);

            //转换成MVC请求上下文
            var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;
            if (mvcContext != null)
            {
                ////Examine MVC specific things like routing data.
                //转换成mvc控制器
                var controllerActionDescriptor = mvcContext.ActionDescriptor as ControllerActionDescriptor;
                requirement.ControllerName = controllerActionDescriptor.ControllerName;
                requirement.ActionName = controllerActionDescriptor.ActionName;

                //判断用户是否有权限访问Action
                if (actionData.FindAll(c => c.ActionName == requirement.ActionName && c.UserId == userdata.Id) != null)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
