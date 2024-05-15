using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class StudentDetailsView
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "StudentId  is required")]
        [Display(Name = "Student Id")]
        [Key]
        public string? StudendId { get; set; }
        [Required(ErrorMessage = "EnrollNo. is required")]
        public string? EnrollNo { get; set; }
        [Required(ErrorMessage = "DateOfBirth  is required")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address  is required")]

        public string? Address { get; set; }
        [Required(ErrorMessage = "MobileNo.  is required")]
        [Phone]
        public string? Mobile { get; set; }
        [Required(ErrorMessage = "Course  is required")]
        public string? Course { get; set; }
        [Required(ErrorMessage = "Branch  is required")]
        public string? Branch { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Father's Name")]
        public string? FatherName { get; set; }
        [Display(Name = "Father's Mobile No.")]
        public string? FatherMobile { get; set; }

        [Display(Name = "Mother's Name")]
        public string? MotherName { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile? ProfileImage { get; set; }


    }
}
