using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lex.Models;
using Microsoft.AspNetCore.Identity;
using static Lex.Areas.Identity.Pages.Account.RegisterModel;

namespace Lex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Iproduct _Iproduct;
        private readonly ICard _Icard;
        private readonly RoleManager<IdentityRole>_rolemanager;
        private readonly SignInManager<Application_user> _signInManager;
        private readonly UserManager<Application_user> _UserManager;
        public HomeController(ILogger<HomeController> logger, ICard Icard, Iproduct Iproduct, RoleManager<IdentityRole> rolemanager, UserManager<Application_user> UserManager, SignInManager<Application_user> signInManager)
        {
            _logger = logger;
            _Iproduct = Iproduct;
            _rolemanager = rolemanager;
            _UserManager = UserManager;
            _signInManager= signInManager;
            _Icard = Icard;
         
        }

        public IActionResult Index()
        {
            
            return View(_Iproduct.Get_AllProducts());
        }
        public IActionResult Card()
        {
            var orders1=_Icard.Get_AllProductsInCard();
            OrderModel orders = new OrderModel();
            string customer_Id = _UserManager.GetUserId(HttpContext.User);
                foreach(var order in orders1)
            {
                if (order.CustomerID.Equals(customer_Id))
                {

                    orders.orders.Add(order);
                    orders.products.Add(_Iproduct.GetProduct(order.ProductID));
                }
            }
            return View(orders);
        }
        [HttpPost]
        public IActionResult AddtoCard(int ProductId)
        {
            _Icard.AddProductToCard(ProductId, _UserManager.GetUserId(HttpContext.User),1);
            return RedirectToAction("Card");
        }
        [HttpPost]
        public IActionResult RemovefromCard(int OrderId)
        {
            _Icard.RemoveproductFromCard(OrderId);
            return RedirectToAction("Card");
        }
        public IActionResult stores()
        {

            return View();
        }
        public IActionResult CreateStore()
        {
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStore(InputModel model)
        {
            var user = new Application_user { UserName = model.Email, Email = model.Email, EmailConfirmed = true, name = model.Name, phone = model.phone };
            var result = await _UserManager.CreateAsync(user, model.Password);
            await _signInManager.SignInAsync(user, isPersistent: false);
            await _UserManager.AddToRoleAsync(user,"store");
            if (result.Succeeded)
            { 
            
               
                return RedirectToAction("index");
            }

            return NotFound();
        }
        public IActionResult Createrole()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> createrole( roleviewmodel model)
        {
            IdentityRole role = new IdentityRole { Name = model.rolename };
           await _rolemanager.CreateAsync(role);

            return RedirectToAction("index");
        }
        [HttpPost]
            public IActionResult search_by_price(string min,string max)
        {

            return View(_Iproduct.search_by_price(min,max));
        }
        [HttpPost]
        public IActionResult search_by_offer_precent(string offer_precent)
        {

            return View(_Iproduct.search_by_offer_precent(offer_precent));
        }

        [HttpPost]
        public IActionResult search_by_seller(string seller_name)
        {

            return View(_Iproduct.search_by_seller(seller_name));
        }
        [HttpPost]
        public IActionResult search_by_category(string selected_category)
        {
          
            return View(_Iproduct.search_by_category(selected_category));
        }
        [HttpGet]

        public IActionResult product_details(int id)
        {

            return View(_Iproduct.GetProduct(id));
        }
        [HttpPost]

        public IActionResult search(string search_input)
        {
            
            return View(_Iproduct.search(search_input));
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
