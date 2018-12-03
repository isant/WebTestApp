using App.Business;
using App.DAL;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace App.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        IUserService service;

        public ValuesController()
        {
            UserRepository repo = new UserRepository();
            CustomMapper customMapper = new CustomMapper();
            service = new UserService(repo, customMapper);
        }

        public IHttpActionResult Get()
        {
            return Ok("FUNCIONA");
        }

        [Route("GetUsers/{id}/{pass}")]
        [HttpGet]
        public IHttpActionResult GetUsers(int id, string pass)
        {
            var autenticationResult = service.UserAutentication(id, pass);

            if (autenticationResult == 0 && service.GetUserById(id).Roles.Exists(x => x.Id == 1)) //Rol de admin
            {
                var users = service.GetUsers().ToList();

                string result = new JavaScriptSerializer().Serialize(users);

                return Ok(result);
            }
            else if (autenticationResult == -1)
                return Content(HttpStatusCode.BadRequest, "Invalid Credentials");
            else
                return Content(HttpStatusCode.Forbidden, "User has no access");
        }

        [Route("CreateUser")]
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            try
            {
                var result = service.CreateUser(user);
                return Ok(result);
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

        [Route("UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser(User user)
        {
            try
            {
                var result = service.UpdateUser(user);
                return Ok(result);
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }







    }
}
