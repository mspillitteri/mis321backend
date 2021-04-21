using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IGetAllCheckouts
    {
         List<Checkouts> GetAllCheckouts();
    }
}