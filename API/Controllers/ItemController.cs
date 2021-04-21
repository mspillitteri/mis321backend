using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        // GET: api/Item
        [EnableCors("Policy")]
        [HttpGet(Name = "GetAllItems")]
        public List<Item> GetAllItems()
        {
            IGetAllItems allItems = new ReadItemData();
            return allItems.GetAllItems();
        }

        // GET: api/Item/5
        [EnableCors("Policy")]
        [HttpGet("{id}", Name = "GetItem")]
        public Item GetItem(int id)
        {
            //System.Console.WriteLine("Returned an id of: " + id);
            IGetItem getItem = new ReadItemData();
            return getItem.GetAnItem(id);
        }

        // POST: api/Item
        [EnableCors("Policy")]
        [HttpPost]
        public void Post([FromBody] Item ivalue)
        {
            IAdd addItem = new Add();
            addItem.AddItem(ivalue);
        }

        // PUT: api/Item/5
        [EnableCors("Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item ivalue)
        {
            IUpdate editItem = new Update();
            editItem.UpdateItem(id, ivalue);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteItem = new Delete();
            deleteItem.DeleteItem(id);
        }
    }
}
