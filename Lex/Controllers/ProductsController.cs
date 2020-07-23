using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lex.Data;
using Microsoft.AspNetCore.Hosting;
using Lex.Models;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Lex.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Iproduct _Iproduct;
        
        private readonly IWebHostEnvironment _Ihosting;
        private readonly SignInManager<Application_user> SignInManager;
        private readonly UserManager<Application_user> UserManager;
        public ProductsController(Iproduct Iproduct, IWebHostEnvironment Ihosting, UserManager<Application_user> userManager, SignInManager<Application_user> signInManager)
        {
            _Iproduct = Iproduct;
            _Ihosting = Ihosting;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_Iproduct.Get_AllProducts());
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
           

            var product = _Iproduct.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Create_product_viewmodel model)
        {
            Product product;
                if (ModelState.IsValid)
            {
                if (model.photo != null)
                {
                    Upload_photo(model.photo);

                }
           product = new Product { Name = model.Name,Rate=0,NewPrice=0, Category = model.Category, photo = model.photo.FileName, Price = model.Price,ShopID= UserManager.GetUserId(HttpContext.User)
            };
                _Iproduct.AddProduct(product);

                return RedirectToAction("Index") ;
            }
            return View();
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            

            var product = _Iproduct.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            edit_product_viewmodel edit = new edit_product_viewmodel { Id = product.Id, Name = product.Name, Price = product.Price, exist_photo_path = product.photo };
                
            
            return View(edit);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,edit_product_viewmodel model)
        {
            if (id != model.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.photo != null)
                    {
                        Upload_photo(model.photo);

                    }
                    Product product = new Product {Id=model.Id, Name = model.Name, Category = model.Category, photo = model.photo.FileName, Price = model.Price, ShopID = UserManager.GetUserId(HttpContext.User) };
                    _Iproduct.Editproduct(product);

                }
                catch
                {
                    //return RedirectToAction("Index");
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        //Discount Get
        public IActionResult Discount(int id)
        {


            var product = _Iproduct.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            Discount_viewmodel model = new Discount_viewmodel();
            model.product.Id = product.Id;
            model.product.Name = product.Name;
            model.product.photo = product.photo;
            model.product.Rate = product.Rate;
            model.product.Price = product.Price;
            model.product.NewPrice = product.NewPrice;
            model.product.Shop = product.Shop;
            model.product.ShopID = product.ShopID;
            return View(model);
        }
        [HttpPost]
        public IActionResult Discount(Discount_viewmodel model,int id)
        {


            
            if (model.product == null)
            {
                return NotFound();
            }
            _Iproduct.Discount(model.discount, id);



            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult RemoveDiscount( int id)
        {



            
            _Iproduct.RemoveDiscount( id);



            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            
            return View(_Iproduct.GetProduct(id));
        }
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Deleteconfirm(int id)
        {
            _Iproduct.Removeproduct(id);
            return RedirectToAction(nameof(Index));
        }

        public void Upload_photo(IFormFile photo)
        {
            string p = Path.Combine(_Ihosting.WebRootPath, "images");
            string p2 = Path.Combine(p, photo.FileName);
            photo.CopyTo(new FileStream(p2, FileMode.Create));


           
        }
    }
}
