using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IGetAllWaitlists
    {
         public List<Waitlist> GetAllWaitlists();
    }
}