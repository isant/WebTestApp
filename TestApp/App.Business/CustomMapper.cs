using App.DAL;
using System.Collections.Generic;
using System.Linq;

namespace App.Business
{
    public class CustomMapper : ICustomMapper
    {
        public CustomMapper() { }

        public User Map(UserModel userModel)
        {
            User user = new User();
            user.Id = userModel.Id;
            user.UserName = userModel.UserName;
            user.setPassword(userModel.Password);
            user.Roles = Map(userModel.Roles);
            return user;
        }

        public UserModel Map(User user)
        {
            UserModel userModel = new UserModel();
            userModel.Id = user.Id;
            userModel.UserName = user.UserName;
            userModel.Password = user.GetPassword();
            userModel.Roles = Map(user.Roles).ToList();
            return userModel;

        }

        public IEnumerable<User> Map(IEnumerable<UserModel> userModelList)
        {
            List<User> userList = new List<User>();
            foreach (var user in userModelList)
                userList.Add(Map(user));

            IEnumerable<User> result = userList;
            return result;
        }

        public IEnumerable<UserModel> Map(IEnumerable<User> userList)
        {
            List<UserModel> userModelList = new List<UserModel>();
            foreach (var user in userList)
                userModelList.Add(Map(user));

            IEnumerable<UserModel> result = userModelList;
            return result;
        }

        public IEnumerable<RolModel> Map(IEnumerable<Rol> rolList)
        {
            List<RolModel> rolModels = new List<RolModel>();
            foreach (var rol in rolList)
                rolModels.Add(this.Map(rol));

            IEnumerable<RolModel> result = rolModels;
            return result;
        }

        public List<Rol> Map(IEnumerable<RolModel> rolModelList)
        {
            List<Rol> rols = new List<Rol>();
            foreach (var rol in rolModelList)
                rols.Add(this.Map(rol));

            return rols;
            
        }

        private Rol Map(RolModel rolModel)
        {
            Rol rol = new Rol();
            rol.Id = rolModel.Id;
            rol.Name = rolModel.Name;
            rol.Description = rolModel.Description;
            return rol;
        }

        private RolModel Map(Rol rol)
        {
            RolModel rolModel = new RolModel();
            rolModel.Id = rol.Id;
            rolModel.Name = rol.Name;
            rolModel.Description = rol.Description;
            return rolModel;
        }


    }
}
