using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IGetWaitlist
    {
         public List<Waitlist> GetItemWaitlist(int itemid);
    }
}