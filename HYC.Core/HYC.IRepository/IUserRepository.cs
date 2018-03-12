using HYC.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.IRepository
{
    public interface IUserRepository: IBaseRepository<UserData>
    {
        UserData Login(string userName, string password);

        bool ValidateLastChanged(string userName, string lastChanged);
    }
}
