using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lex.Models
{
    public class Application_user:IdentityUser
    {
       
        
        public string name { get; set; }
        
        public string phone { get; set; }
    }
}
