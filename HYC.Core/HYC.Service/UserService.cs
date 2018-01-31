using HYC.Model.Users;
using HYC.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Insert(UserInfo entity)
        {
            return _userRepository.Insert(entity);
        }
    }
}
