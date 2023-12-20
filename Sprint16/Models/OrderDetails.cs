﻿namespace Sprint16.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }


        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
