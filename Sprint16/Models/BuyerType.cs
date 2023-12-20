namespace Sprint16.Models
{
    public enum BuyerCategory
    {
        None,
        Regular,
        Golden,
        Wholesale
    }
    public class BuyerType
    {
        public int Id { get; set; }
        public BuyerCategory Category { get; set; }
    }
}
