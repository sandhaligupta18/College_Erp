using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class Hostel
    {
        [Required]
        [Display(Name = "Student Name")]
        public string? StudentName { get; set; }
        [Key]
        [Display (Name = "Enroll No.")]
        [Required]
        public string? EnrollNo { get; set; }
        [Display(Name = "Hostel Name")]
        [Required]
        public string? HostelName { get; set; }
        [Display (Name = "Room No.")]
        [Required]
        public int? RoomNo { get; set; }
        [Display (Name ="Allocation Date")]
        [Required]
        public DateTime? AllocationDate { get; set; }
        [Display(Name = "IsActive")]
        [Required]
        public bool? IsActive { get; set; }
        [Display(Name = "Total Fee")]
        [Required]
        public Int64? TotalFee { get; set; }
        [Display(Name = "Submitted Fee")]
        [Required]
        public Int64? SubmittedFee { get; set; }
        [Display(Name = "Pending Fee")]
        [Required]
        public Int64? PendingFee { get; set; }
       
    }
}
