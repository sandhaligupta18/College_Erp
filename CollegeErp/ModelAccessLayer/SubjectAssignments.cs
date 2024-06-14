using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class SubjectAssignments
    {
        [Key]
        public int AssignmentsId { get; set; }
        public string? SubjectId { get; set; }
        public string? Course { get; set; }
        public string? Branch { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string? FilePath { get; set; }


    }

}
