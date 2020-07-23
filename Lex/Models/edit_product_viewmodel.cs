using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public class edit_product_viewmodel:Create_product_viewmodel
    {

       
        public int Id { get; set; }
        
        public string exist_photo_path { get; set; }
        
       
    }
}
