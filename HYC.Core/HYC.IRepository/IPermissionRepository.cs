using HYC.Model.Permission;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.IRepository
{
    public interface IPermissionRepository
    {
        List<ActionAuthorizes> GetActionAuthorizesList(int userId);
    }
}
