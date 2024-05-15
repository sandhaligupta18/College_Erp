using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
	public interface ITeacherOperations
	{

		public Task<bool> AddTeacher(TeacherDetails teacherDetails);
		public Task<IEnumerable<TeacherDetails>> GetTeacherDetails();
        public Task<bool> UpdateTeacher(TeacherDetails teacherDetails);
        //public Task<TeacherDetails> GetTeacherById(string TeacherId);
        	public Task<TeacherDetails> GetUserBy(string TeacherId);
        public Task<bool> DeleteTeacher(string TeacherId);

		//Stored Procedure
		public List<TeacherDetails> GetTeacher(string TeacherId);

	}
}
