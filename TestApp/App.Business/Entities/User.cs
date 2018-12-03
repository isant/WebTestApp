using System.Collections.Generic;

namespace App.Business
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; }
        public List<Rol> Roles {get;set;}
        
        public User()
        {
            Roles = new List<Rol>();
        }   
        
        public void setPassword(string password)
        {
            this.Password = password;
        }

        public string GetPassword()
        {
            return this.Password;
        }
    }
}
