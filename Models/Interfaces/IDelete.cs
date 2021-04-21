namespace API.Models.Interfaces
{
    public interface IDelete
    {
       public void DeleteItem(int itemid); 
       public void DeleteUser(int userid);
       public void DeleteCheckout(int checkoutid);
       public void DeleteWaitlist(int waitlistid);
    }
}