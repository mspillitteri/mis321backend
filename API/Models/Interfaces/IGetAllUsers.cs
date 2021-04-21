using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IGetAllUsers
    {
         List<User> GetAllUsers();
    }
}