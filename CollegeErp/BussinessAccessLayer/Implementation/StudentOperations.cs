using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
	public class StudentOperations:IStudentOperations
	{
        private readonly AppDB_Context _appDBContext;
        private readonly IHostingEnvironment _hostingEnvironment;
             
       
        public StudentOperations(AppDB_Context appDBContext ,IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _appDBContext = appDBContext;
        }
        public async Task<bool> AddStudent(StudentDetailsView model)
        {
            try
            {
                var ifExist = _appDBContext.StudentData.Where(x => x.StudendId== model.StudendId);
                if (ifExist.Any())
                {
                    return false;
                }
                else
                {
                    string uniqueFileName = UploadedFile(model);
                    StudentDetails studentdetail = new()
                    {
                        FirstName= model.FirstName,
                        LastName= model.LastName,
                        StudendId= model.StudendId,
                        EnrollNo= model.EnrollNo,
                        DateOfBirth = model.DateOfBirth,
                        Address = model.Address,
                        Mobile = model.Mobile,
                        Course = model.Course,
                        Branch = model.Branch,
                        Email = model.Email,
                        FatherName = model.FatherName,
                        FatherMobile= model.FatherMobile,
                        MotherName = model.MotherName,
                        ProfilePicture = uniqueFileName,


                    };
                    _appDBContext.StudentData.Add(studentdetail);
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


        private string UploadedFile(StudentDetailsView model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                Random rndm = new Random();
                int uniqnum = rndm.Next();
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath  , "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + (uniqnum+ model.ProfileImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<IEnumerable<StudentDetails>> GetStudentDetails()
        {
            try
            {
                var result = await _appDBContext.StudentData.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StudentDetails> GetUserById(string StudendId)
        {
            return await _appDBContext.StudentData.FindAsync(StudendId);
        }


        public async Task<bool> UpdateStudent(StudentDetails studentDetails)
        {

            try
            {
                _appDBContext.StudentData.Update(studentDetails);
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
        public async Task<bool> DeleteStudent(string StudendId)
        {
            try
            {
                if (_appDBContext.StudentData == null)
                {
                    return false;
                }
                var data = await _appDBContext.StudentData.FindAsync(StudendId);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.StudentData.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //stored Procedure

        public List<StudentDetails> GetStudentById(string EnrollNo)
        {
            using (_appDBContext)
            {
                return _appDBContext.StudentData.FromSqlRaw<StudentDetails>("EXEC StudentById @EnrollNo",

                    new SqlParameter("@EnrollNo", EnrollNo)).ToList();
            }
        }

   
   

    }
}
