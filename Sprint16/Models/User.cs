﻿namespace Sprint16.Models
{
    //public enum BuyerType
    //{
    //    None,
    //    Regular,
    //    Golden,
    //    Wholesale
    //}
    public class User
    {
        public int Id { get; set; } 
        public string Email {  get; set; }
        public string Password { get; set; }

        public int? RoleId {  get; set; }   
        public Role Role { get; set; }

        public int BuyerTypeId { get; set; }
        public virtual BuyerType _BuyerType { get; set; }
    }
}
