using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class LibraryDetails
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? IssuedBy { get; set; }
      
        [Required]
        [Display(Name = "Enroll No.")]
        public string? EnrollNo { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string? BookName { get; set;}
        [Required]
        public DateTime? IssuedOn { get; set; }
        [Required]
        public DateTime? ReturnDate { get; set; }
    }
}
