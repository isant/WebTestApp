using App.DAL;
using System.Collections.Generic;

namespace App.Business
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private ICustomMapper mapper;

        public UserService(IUserRepository repository, ICustomMapper customMapper)
        {
            userRepository = repository;
            mapper = customMapper;
        }

        public int UserAutentication(int id, string password)
        {
            UserModel userModel = userRepository.GetUserById(id);

            if (userModel != null)
            {
                if (userModel.Password == password)
                {
                    return 0;
                }

                return -1;
            }
            else
                return -2;
        }

        public int CreateUser(User user)
        {
            UserModel userModel = mapper.Map(user);
            userModel.Id = 0;
            return userRepository.AddNewUser(userModel);
        }

        public User GetUserById(int Id)
        {
            UserModel userModel = userRepository.GetUserById(Id);


            return mapper.Map(userModel);
        }

        public IEnumerable<User> GetUsers()
        {
            ResponseItem response = new ResponseItem();
            var users = userRepository.GetUsers();

            return mapper.Map(users);
        }

        public bool UpdateUser(User user)
        {
            UserModel userModel = userRepository.GetUserById(user.Id);


            var userResult = mapper.Map(userModel);
            userResult.UserName = user.UserName;
            userResult.Roles = user.Roles;
            userResult.setPassword(user.GetPassword());

            var userReturn = mapper.Map(userResult);

            return userRepository.UpdateUser(userReturn);
        }

        public int UserAutentication(User user)
        {
            var userModel = userRepository.GetUserById(user.Id);

            if (userModel != null)
            {
                if (user.GetPassword().ToLowerInvariant() == userModel.Password.ToLowerInvariant())
                {
                    return 0;

                }

                return -1;
            }
            else
            {
                return -2;

            }
        }

        public IEnumerable<Rol> GetRoles()
        {
            var rolesModels = userRepository.GetRoles();

            return mapper.Map(rolesModels);
        }
    }
}
