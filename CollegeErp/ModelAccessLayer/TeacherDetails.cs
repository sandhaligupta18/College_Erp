using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class TeacherDetails
    {

        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        [Key]
        [Required(ErrorMessage = "TeacherId  is required")]        
        public string? TeacherId { get; set; }
        [Required(ErrorMessage = "DateOfBirth  is required")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address  is required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "MobileNo.  is required")]
        [Phone]
        public string? Mobile { get; set; }
        [Required(ErrorMessage = "Department  is required")]
        public string? Department { get; set; }
        [Required(ErrorMessage = "Subject  is required")]
        public string? SubjectTeach { get; set; }

    }
}
