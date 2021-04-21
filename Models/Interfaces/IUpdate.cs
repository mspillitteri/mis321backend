namespace API.Models.Interfaces
{
    public interface IUpdate
    {
         public void UpdateCheckOut(int checkoutid, Checkouts cvalue);
         public void UpdateItem(int itemid, Item ivalue);
         public void UpdateUser(int userid, User uvalue);
         public void UpdateWaitlist(int waitlistid, int itemid, int userid);
    }
}