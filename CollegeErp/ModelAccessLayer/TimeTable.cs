using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class TimeTable
    {
        [Key]
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string? SubjectId { get; set; }
        public string? Days { get; set; }
        public string? Branch { get; set; }
        public DateTime? StartLecture {get; set;}
        public DateTime? EndLecture { get; set; }
    }
}
