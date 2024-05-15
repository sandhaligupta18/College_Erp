using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class FeeStructure
    {
        [Required]
        public string? StudentName { get; set; }
        [Key]
        [Required]
        public string? EnrollNo { get; set; }
        [Required]
        public string? Course { get; set; }
        [Required]
        public string? Branch { get; set; }
        public decimal? ConcessionDiscount { get; set; }
        public decimal? TotalFees { get; set; }
        [Required]
        public decimal? SubmittedFees { get; set; }
        [Required]
        public decimal? PendingFees { get;set; }

    }
}
