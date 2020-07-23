using Lex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public class Implement_product : Iproduct
    {
        public readonly ApplicationDbContext db;
        public Implement_product(ApplicationDbContext db)
        {
            this.db = db;
        }

         IEnumerable<Product> Iproduct.search_by_category(string search_caegory)
        {
            List<Product> p = new List<Product>();
            foreach (var i in db.products)
            {
                if (i.Category.ToString().Equals(search_caegory)) { p.Add(i); }
            }
            return (p);
        }

        void Iproduct.AddProduct(Product product)
        {
            db.products.Add(product);
            db.SaveChanges();
        }
        
        void Iproduct.Discount(string Discount, int id)
        {
            var product = db.products.Find(id);
            product.NewPrice = product.Price - (int)((double)product.Price * (double)(double.Parse(Discount) / 100.0));
            db.Update(product);
            db.SaveChanges();
        }
        void Iproduct.RemoveDiscount(int id)
        {
            var product = db.products.Find(id);
            product.NewPrice =0;
            db.Update(product);
            db.SaveChanges();
        }

        void Iproduct.Editproduct( Product product)
        {
            db.products.Update(product);
            db.SaveChanges();
        }

        Product Iproduct.GetProduct(int id)
        {

            return db.products.Find(id);
        }

        IEnumerable<Product> Iproduct.Get_AllProducts()
        {
            return db.products;
        }

        void Iproduct.Removeproduct(int id)
        {
            db.products.Remove(db.products.Find(id));
            db.SaveChanges();
        }

        IEnumerable<Product> Iproduct.search(string search_input)
        {
           return db.products.Where(p => p.Name.Contains(search_input));
        }

      

        IEnumerable<Product> Iproduct.search_by_price(string min, string max)
        {
            double mi, ma;
            mi = int.Parse(min);
            ma = int.Parse(max);
            return db.products.Where(p => p.Price >= mi && p.Price <= ma);
        }

        IEnumerable<Product> Iproduct.search_by_seller(string name)
        {
           return db.products.Where(s => s.Shop.name == name);
        }
        
         IEnumerable<Product> Iproduct.search_by_offer_precent(string offer_precent)
        {
           double  offer_precent2 = double.Parse(offer_precent);
            var l= db.products.Where(s => s.NewPrice!=0&&((double)(s.Price-s.NewPrice)/s.Price)*100>=(offer_precent2));
            return l; 
        }
    }
}
