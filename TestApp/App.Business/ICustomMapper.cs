using App.DAL;
using System.Collections.Generic;

namespace App.Business
{
    public interface ICustomMapper
    {
        User Map(UserModel userModel);     
        UserModel Map(User user);
        IEnumerable<User> Map(IEnumerable<UserModel> userModelList);
        IEnumerable<UserModel> Map(IEnumerable<User> userList);
        IEnumerable<RolModel> Map(IEnumerable<Rol> rolList);
        List<Rol> Map(IEnumerable<RolModel> rolModelList);       
    }
}
