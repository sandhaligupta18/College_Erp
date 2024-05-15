using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
	public interface IStudentOperations
	{
        public Task<bool> AddStudent(StudentDetailsView  studentDetails);
        public Task<IEnumerable<StudentDetails>> GetStudentDetails();
        public Task<StudentDetails> GetUserById(string StudendId);
        public Task<bool> UpdateStudent(StudentDetails studentDetails);
        public Task<bool> DeleteStudent(string StudendId);

     

        //StoredProcedure

        public List<StudentDetails> GetStudentById(string EnrollNo);


    }
}
