using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ModelAccessLayer
{
    public class RegisterUser : IdentityUser
    {

        public string? FirstName { get; set; }
      
        public string? LastName { get; set; }
       public string? Address { get; set; }
         public string? RegisterAs { get; set; }
       

    }
    
}
