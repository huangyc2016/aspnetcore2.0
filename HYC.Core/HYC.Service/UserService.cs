using HYC.IRepository;
using HYC.IService;
using HYC.Model.Users;


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

        /// <summary>
        /// 通过ID获取用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserInfo GetByID(int ID)
        {
            return _userRepository.GetByID(ID);
        }
    }
}
