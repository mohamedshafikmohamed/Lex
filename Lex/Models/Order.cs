using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lex.Models
{
    public class Order
    {
       
        public int Id { get; set; }
        public string CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity{ get; set; }
        public virtual Product Product { get; set; }
        public virtual Application_user Customer { get; set; }

    }
}
