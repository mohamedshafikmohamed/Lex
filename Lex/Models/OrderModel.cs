using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public class OrderModel
    {
        public List<Order> orders { get; set; }
        public List<Product>products { get; set; }
        public OrderModel()
        {
            orders = new List<Order>();
            products = new List<Product>();
        }
    }
}
