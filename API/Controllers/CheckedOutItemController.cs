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
    public class CheckedOutItemController : ControllerBase
    {
        // GET: api/CheckedOutItem
        [EnableCors("Policy")]
        [HttpGet]
        public List<CheckedOutItems> GetCheckedOutItems()
        {
            IReport checkedOut = new AllReports();
            return checkedOut.ReportCheckedOutItems();
        }

        // GET: api/CheckedOutItem/5
        [EnableCors("Policy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckedOutItem
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CheckedOutItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
