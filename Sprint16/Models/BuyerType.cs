namespace Sprint16.Models
{
   
    public class BuyerType
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public List<User> Users { get; set; }   

        public BuyerType() 
        {
            Users = new List<User>();
        }  
    }
}
