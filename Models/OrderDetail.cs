﻿namespace PizzaPointProject.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Pizzas Pizza { get; set; }
        public virtual Order Order { get; set; }
    }
}
