using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
        public class SetNewPassword
	{
		[Required]
		public string? Email { get; set; }
		[Required]
		[Display (Name ="Current Password")]
		public string? CurrentPassword { get; set; }
		[Required]
		[Display(Name = "New Password")]
		public string? NewPassword { get; set; }

	}
}
