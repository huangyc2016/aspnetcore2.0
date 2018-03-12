using HYC.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using HYC.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;

namespace HYC.Admin.Components
{
    [ViewComponent(Name = "UserData")]
    public class UserDataViewComponent : ViewComponent
    {
        public UserDataViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userdata = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            UserData model = JsonConvert.DeserializeObject<UserData>(userdata);
            return await Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
