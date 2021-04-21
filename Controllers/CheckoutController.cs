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
    public class CheckoutController : ControllerBase
    {
        // GET: api/Checkout
        [EnableCors("Policy")]
        [HttpGet]
        public List<Checkouts> GetAllCheckouts()
        {
            IGetAllCheckouts allCheckouts = new ReadCheckoutData();
            return allCheckouts.GetAllCheckouts();
        }

        // GET: api/Checkout/5
        [EnableCors("Policy")]
        [HttpGet("{id}", Name = "GetCheckout")]
        public string GetCheckout(int id)
        {
            return "value";
        }

        // POST: api/Checkout/5
        [EnableCors("Policy")]
        [HttpPost("{id}")]
        public void PostCheckout([FromBody] Item ivalue, int id)
        {
            ICheckout addCheckout = new ProcessCheckouts();
            addCheckout.AddCheckout(ivalue, id);
        }

        // PUT: api/Checkout/5
        [EnableCors("Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Checkouts cvalue)
        {
            IUpdate updateCheckout = new Update();
            updateCheckout.UpdateCheckOut(id, cvalue);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteCheckout = new Delete();
            deleteCheckout.DeleteCheckout(id);
        }
    }
}
