using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public class Create_product_viewmodel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Category_name Category { get; set; }
        [Required]
        public IFormFile photo { get; set; }
        
    }
}
