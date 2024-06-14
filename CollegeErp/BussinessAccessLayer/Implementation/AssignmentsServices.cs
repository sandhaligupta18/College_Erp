using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
    public class AssignmentsServices:IAssignmentsServices
    {

        private readonly AppDB_Context _appDBContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AssignmentsServices(AppDB_Context appDBContext , IHostingEnvironment hostingEnvironment)
        {
            _appDBContext = appDBContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> AddAssignments(SubjectAssignmentsView subjectAssignments)
        {
            try
            {
                var ifExist = _appDBContext.subjectAssignments.Where(x => x.AssignmentsId == subjectAssignments.AssignmentsId);
                if (ifExist.Any())
                {
                    return false;
                }
                else
                {
                    string uniqueFileName = UploadedFiles(subjectAssignments);
                    SubjectAssignments subjectAssignments1 = new() { 
                    SubjectId = subjectAssignments.SubjectId,
                    Branch = subjectAssignments.Branch,
                    Course = subjectAssignments.Course,
                    CompletionDate = subjectAssignments.CompletionDate,
                        FilePath = uniqueFileName,
                    };
                    _appDBContext.subjectAssignments.Add(subjectAssignments1);
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


		public async Task<IEnumerable<SubjectAssignments>> GetAssignDetails()
		{
			try
			{
				var result = await _appDBContext.subjectAssignments.ToListAsync();

				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<SubjectAssignments> GetAssignById(int AssignmentsId)
		{
			return await _appDBContext.subjectAssignments.FindAsync(AssignmentsId);

		}
		public async Task<bool> UpdateAssignment(SubjectAssignments subjectAssignments)
		{
			try
			{
				_appDBContext.subjectAssignments.Update(subjectAssignments);
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

               public async Task<bool> DeleteAssignment(int AssignmentsId)
        {
            try
            {
                if (_appDBContext.subjectAssignments == null)
                {
                    return false;
                }
                var data = await _appDBContext.subjectAssignments.FindAsync(AssignmentsId);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.subjectAssignments.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


		private string UploadedFiles(SubjectAssignmentsView model)
        {
            string uniqueFileName = null;

            if (model.File != null)
            {
                var fileName = Path.GetFileName(model.File.FileName);
              
                string ext = Path.GetExtension(model.File.FileName);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    model.File.CopyToAsync(fileSteam);
                }
            }
            return uniqueFileName;
        }

    }
}
