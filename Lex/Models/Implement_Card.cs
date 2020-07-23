using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lex.Data;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

using System.Diagnostics;

using Microsoft.Extensions.Logging;

namespace Lex.Models
{
    public class Implement_Card:ICard
    {
        public readonly ApplicationDbContext db;
        private readonly UserManager<Application_user> _userManager;
        public Implement_Card(ApplicationDbContext db, UserManager<Application_user> userManager)
        {
            this.db = db;
            _userManager = userManager;
        }

        void ICard.AddProductToCard(int ProductId, string CustomerId,int Quantity)
        {
            Order r = new Order();
            r.CustomerID = CustomerId;
            r.ProductID = ProductId;
            r.Quantity = Quantity;
            db.Orders.Add(r);
            db.SaveChanges();
        }

        IEnumerable<Order> ICard.Get_AllProductsInCard()
        {
            return db.Orders;
        }
       
        void ICard.RemoveproductFromCard(int id)
        {
            var order = db.Orders.Find(id);
            db.Remove(order);
            db.SaveChanges();
        }
    }
}
