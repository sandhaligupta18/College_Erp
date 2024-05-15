using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
	public class TeacherController : Controller
	{

		private readonly ILogger<HomeController> _logger;
		private readonly ITeacherOperations _teacherOperations;

		public TeacherController(ILogger<HomeController> logger , ITeacherOperations teacherOperations )
		{
			_logger = logger;
			_teacherOperations = teacherOperations;
		}
		public IActionResult AddTeacher()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> AddTeacher(TeacherDetails teacherDetail)
        {
            try
            {
                _logger.LogInformation("Add Department in progress....");
                if (ModelState.IsValid)
                {
                    var result = await _teacherOperations.AddTeacher(teacherDetail);
                    if (result)
                    {
                        
                        return RedirectToAction("AddTeacher");
                    }
                    else
                    {
                        return View();
                    }                 
                } 
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong" + ex);
                throw;
            }
        }
        public async Task<IActionResult> GetAllTeachers()
        {
            var data = await _teacherOperations.GetTeacherDetails();

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserById(string Id)
        {
          var data =  await _teacherOperations.GetUserBy(Id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTeacher(string Id)
        {
            var values = await _teacherOperations.GetUserBy(Id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeacher(TeacherDetails teacherDetails)
        {
            await _teacherOperations.UpdateTeacher(teacherDetails);
            return RedirectToAction("GetAllTeachers");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTeacher(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _teacherOperations.DeleteTeacher(id);
                return RedirectToAction("GetAllTeachers");
            }
            else
            {
                return View();
            }
        }

		//Stored Procedure
		public IActionResult GetIndividualTeacher()
		{
			//HttpContext.Session.GetString("Enroll");
			var data = _teacherOperations.GetTeacher(HttpContext.Session.GetString("Enroll").ToString());
			return View(data);
		}
	}
    }
