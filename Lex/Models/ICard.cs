using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public interface ICard
    {
        public IEnumerable<Order> Get_AllProductsInCard();
        public void AddProductToCard(int ProductId ,string CustomerId, int Quantity);
        public void RemoveproductFromCard(int id);

    }
}
