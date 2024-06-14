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
    public class AssignmentServices:IAssignmentServicescs
    {
        private readonly AppDB_Context _appDBContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AssignmentServices(AppDB_Context appDBContext, IHostingEnvironment hostingEnvironment)
        {
            _appDBContext = appDBContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<bool> AddAssignment(AssignmentViews assignment)
        {
            try
            {
                var ifExist = _appDBContext.Assignments.Where(x => x.AssignId == assignment.AssignId);
                if (ifExist.Any())
                {
                    return false;
                }
                else
                {
                    string uniqueFileName = UploadedFiles(assignment);
                    Assignment assignments = new()
                    {
                        SubjectId = assignment.SubjectId,
                        Course = assignment.Course,
                        Branch = assignment.Branch,
                        CompletionDate = assignment.CompletionDate,
                        FilePath = uniqueFileName,

                    };
                    _appDBContext.Assignments.Add(assignments);
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
        private string UploadedFiles(AssignmentViews model)
        {
            string uniqueFileName = null;

            if (model.File != null)
            {
                var fileName = Path.GetFileName(model.File.FileName);
                //judge if it is pdf file
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

 

        public async Task<IEnumerable<Assignment>> GetAssignmentDetails()
        {
            try
            {
                var result = await _appDBContext.Assignments.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        public async Task<Assignment> GetAssignment(int AssignId)
        {
            return await _appDBContext.Assignments.FindAsync(AssignId);
        }
        public async Task<bool> UpdateAssignment(Assignment assignment)
        {
            try
            {
                _appDBContext.Assignments.Update(assignment);
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
        public async Task<bool> DeleteAssignment(string SubjectId)
        {
            try
            {
                if (_appDBContext.Assignments == null)
                {
                    return false;
                }
                var data = await _appDBContext.Assignments.FindAsync(SubjectId);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.Assignments.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public Task<Assignment> DownloadFile(string FilePath)
        //{

        //    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
        //    string fileName = "myfile.pdf";
        //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //}
    }
}

