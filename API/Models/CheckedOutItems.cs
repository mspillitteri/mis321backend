namespace API.Models
{
    public class CheckedOutItems
    {
        public int itemid {get;set;}
        public string itemname {get;set;}
        public string userfname {get;set;}
        public string userlname {get;set;}
        public System.DateTime duedate{get; set;}
    }
}