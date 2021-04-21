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
    public class WaitlistController : ControllerBase
    {
        // GET: api/Waitlist
        [EnableCors("Policy")]
        [HttpGet]
        public List<Waitlist> GetAllWaitlists()
        {
            IGetAllWaitlists getWaitlists = new ReadWaitlistData();
            return getWaitlists.GetAllWaitlists();
        }

        // GET: api/Waitlist/5
        [EnableCors("Policy")]
        [HttpGet("{id}")]
        public List<Waitlist> GetWaitlist(int id)
        {
            IGetWaitlist getWaitlist = new ReadWaitlistData();
            return getWaitlist.GetItemWaitlist(id);
        }

        // POST: api/Waitlist
        [EnableCors("Policy")]
        [HttpPost("{id}")]
        public void PostWaitlist([FromBody] Item ivalue, int id)
        {
            IAddWaitlist addWaitlist = new ProcessWaitlists();
            addWaitlist.AddWaitlist(ivalue, id);
        }

        // PUT: api/Waitlist/5
        [EnableCors("Policy")]
        [HttpPut("{waitlistid}/{itemid}/{userid}")]
        public void Put(int waitlistid, int itemid, int userid)
        {
            IUpdate editWaitlist = new Update();
            editWaitlist.UpdateWaitlist(waitlistid, itemid, userid);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteWaitlist = new Delete();
            deleteWaitlist.DeleteWaitlist(id);
        }
    }
}
