using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lex.Models;
namespace Lex.Models
{
    public class fill_enum
    {
        public List<string> categories;
        public List<string> icon_classes;
        public fill_enum()
        {
            
            categories = new List<string>();
            icon_classes= new List<string>();
            categories.Add(Category_name.Clothes.ToString());
            icon_classes.Add("fas fa-tshirt");
            categories.Add(Category_name.Electronics.ToString());
            icon_classes.Add("fas fa-plug");
            categories.Add(Category_name.Health_Beauty.ToString());
            icon_classes.Add("fas fa-stethoscope");
           
            categories.Add(Category_name.kitchen.ToString());
            icon_classes.Add("fas fa-blender");
            categories.Add(Category_name.Mobiles_tablets_Laptops.ToString());
            icon_classes.Add("fas fa-mobile - alt");
            
            categories.Add(Category_name.Toys.ToString());
            icon_classes.Add("fas fa-table-tennis");
            categories.Add(Category_name.Tvs.ToString());
            icon_classes.Add("fas fa-tv");
            categories.Add(Category_name.Magazines.ToString());
            icon_classes.Add("fas fa-book-open");
            categories.Add(Category_name.Supermarket.ToString());
            icon_classes.Add("fas fa-apple-alt");
            categories.Add(Category_name.Games.ToString());
            icon_classes.Add("fas fa-gamepad");
            categories.Add(Category_name.Sports.ToString());
            icon_classes.Add(" far fa-futbol");
           

        }
    }
}
