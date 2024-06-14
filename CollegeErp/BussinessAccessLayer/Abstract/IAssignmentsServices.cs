using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
   public interface IAssignmentsServices
    {
	//New One
        public Task<bool> AddAssignments(SubjectAssignmentsView subjectAssignments);
		public Task<IEnumerable<SubjectAssignments>> GetAssignDetails();
		public Task<SubjectAssignments> GetAssignById(int AssignmentsId);
		public Task<bool> UpdateAssignment(SubjectAssignments subjectAssignments);

        public Task<bool> DeleteAssignment(int AssignmentsId);


    }
}
