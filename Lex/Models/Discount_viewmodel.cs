using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public class Discount_viewmodel
    {
        public Product product { get; set; }
        public string discount { get; set; }
        public Discount_viewmodel()
        {
            product = new Product();
        }
      
    }
}
