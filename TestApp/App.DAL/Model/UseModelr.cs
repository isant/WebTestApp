using System.Collections.Generic;

namespace App.DAL
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<RolModel> Roles { get; set; }

        public UserModel()
        {
            Roles = new List<RolModel>();
        }
    }
}
