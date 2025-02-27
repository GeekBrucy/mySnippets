using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}