using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [EnableCors("Policy")]
        [HttpGet]
        public List<User> GetAllUsers()
        {
            IGetAllUsers getAllUsers = new ReadUserData();
            return getAllUsers.GetAllUsers();
        }

        // GET: api/User/5
        [EnableCors("Policy")]
        [HttpGet("{id}", Name = "GetUser")]
        public User GetUser(int id)
        {
            IGetUser getUser = new ReadUserData();
            return getUser.GetAUser(id);
        }

        // POST: api/User
        [EnableCors("Policy")]
        [HttpPost]
        public void Post([FromBody] User uvalue)
        {
            IAdd addUser = new Add();
            addUser.AddUser(uvalue);
        }

        // PUT: api/User/5
        [EnableCors("Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User uvalue)
        {
            IUpdate updateUser = new Update();
            updateUser.UpdateUser(id, uvalue);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteUser = new Delete();
            deleteUser.DeleteUser(id);
        }
    }
}
