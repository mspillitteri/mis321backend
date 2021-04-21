using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IReport
    {
         public List<CheckedOutItems> ReportCheckedOutItems();
         public List<Item> ReportInventory();
    }
}