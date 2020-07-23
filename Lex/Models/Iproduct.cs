using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public interface Iproduct
    {
        public Product GetProduct(int id);
        public IEnumerable< Product> Get_AllProducts();
        public void AddProduct(Product product);
        public void Removeproduct(int id);
        public void Editproduct(Product product);
        public IEnumerable<Product> search(string search_input);
        public IEnumerable<Product> search_by_category(string search_caegory);
        public IEnumerable<Product> search_by_price(string min,string max);
        public IEnumerable<Product> search_by_seller(string name);
        public IEnumerable<Product> search_by_offer_precent(string name);
        
        public void Discount(string Discount,int id);
        public void RemoveDiscount(int id);
    }
}
