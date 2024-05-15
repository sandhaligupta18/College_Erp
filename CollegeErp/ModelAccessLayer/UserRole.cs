using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public  class UserRole
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
