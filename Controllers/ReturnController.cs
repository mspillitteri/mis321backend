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
    public class ReturnController : ControllerBase
    {
        // GET: api/Return
        [EnableCors("Policy")]
        [HttpGet]
        public IEnumerable<string> GetAllReturns()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Return/5
        [EnableCors("Policy")]
        [HttpGet("{id}", Name = "GetReturn")]
        public string GetReturn(int id)
        {
            return "value";
        }

        // POST: api/Return/5
        [EnableCors("Policy")]
        [HttpPost("{userid}/{userstat}/{itemid}")]
        public void PostReturn([FromBody] Checkouts cvalue, int userid, int userstat, int itemid)
        {
            IReturn addReturn = new ProcessReturns();
            addReturn.AddReturn(cvalue, userid, userstat, itemid);
        }

        // PUT: api/Return/5
        [EnableCors("Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
