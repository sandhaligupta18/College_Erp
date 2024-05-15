using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BussinessAccessLayer.Implementation
{
	public class TeacherOperations:ITeacherOperations
	{

		private readonly AppDB_Context _appDBContext;

		public TeacherOperations(AppDB_Context appDBContext)
		{
			_appDBContext = appDBContext;
		}

		public async Task<bool> AddTeacher(TeacherDetails teacherDetail )
		{
			try
			{
				var ifExist = _appDBContext.TeacherData.Where(x => x.TeacherId == teacherDetail.TeacherId);
				if (ifExist.Any())
				{
					return false;
				}
				else
				{
				     TeacherDetails teacherdetail = new()
					{
						 FirstName = teacherDetail.FirstName,
						 LastName = teacherDetail.LastName,
						 TeacherId = teacherDetail.TeacherId,
						 DateOfBirth = teacherDetail.DateOfBirth,
						 Address = teacherDetail.Address,
						 Mobile= teacherDetail.Mobile,
						 Department = teacherDetail.Department,
						 SubjectTeach = teacherDetail.SubjectTeach
					 };
					_appDBContext.TeacherData.Add(teacherdetail);
					var result = await _appDBContext.SaveChangesAsync();

					if (result > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch
			{
				return false;
			}
		}

        public async Task<IEnumerable<TeacherDetails>> GetTeacherDetails()
        {
            try
            {
                var result = await _appDBContext.TeacherData.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TeacherDetails> GetUserBy(string TeacherId)
        {
            return await _appDBContext.TeacherData.FindAsync(TeacherId);

        }
        public async Task<bool> UpdateTeacher(TeacherDetails teacherdetail)
		{

            try
            {
                _appDBContext.TeacherData.Update(teacherdetail);
                var result = await _appDBContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> DeleteTeacher(string TeacherId)
        {
            try
            {
                if (_appDBContext.TeacherData == null)
                {
                    return false;
                }
                var data = await _appDBContext.TeacherData.FindAsync(TeacherId);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.TeacherData.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

		//Stored Procedure
		public List<TeacherDetails> GetTeacher(string TeacherId)
		{
			using (_appDBContext)
			{
				return _appDBContext.TeacherData.FromSqlRaw<TeacherDetails>("EXEC GetTeacherDetail @TeacherId",

					new SqlParameter("@TeacherId", TeacherId)).ToList();
			}
		}


	}
}
