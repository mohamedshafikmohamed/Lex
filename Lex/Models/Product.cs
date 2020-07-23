using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category_name Category { get; set; }
        public string photo { get; set; }
        [ForeignKey("Shop")]
        public string ShopID { get; set; }
        public double NewPrice { get; set; }
        public int Rate { get; set; }
        public virtual Application_user Shop { get; set; }




    }
}
