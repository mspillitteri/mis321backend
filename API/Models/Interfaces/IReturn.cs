using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IReturn
    {
         public void AddReturn(Checkouts cvalue, int userid, int userstatus, int ivalue);

         //public List<CheckedOutItems> ListReturnItems(int userid);
    }
}