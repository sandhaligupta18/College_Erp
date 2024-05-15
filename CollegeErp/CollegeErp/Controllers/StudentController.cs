using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
	public class StudentController : Controller
	{

        private readonly ILogger<HomeController> _logger;
		private readonly IStudentOperations _studentOperations;

        public StudentController(ILogger<HomeController> logger, IStudentOperations studentOperations)
        {
            _logger = logger;
            _studentOperations = studentOperations;
        }

        //[Authorize(Roles = "Teacher")]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDetailsView studentDetails)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var result = await _studentOperations.AddStudent(studentDetails);
                    if (result)
                    {
                       

                        return RedirectToAction("AddStudent");
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
        //[Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetAllStudents()
        {
            var data = await _studentOperations.GetStudentDetails();
            return View(data);
        }

        //[Authorize(Roles = "Teacher , Student")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(string Id)
        {
            var data = await _studentOperations.GetUserById(Id);
            return View(data);
        }
       
        [HttpGet]
        public async Task<IActionResult> UpdateStudent(string Id)
        {
            var values = await _studentOperations.GetUserById(Id);
            return View(values);
        }

        //[Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task<IActionResult> UpdateStudent(StudentDetails studentDetails)
        {
            await _studentOperations.UpdateStudent(studentDetails);
            return RedirectToAction("GetAllStudents");
        }

        //[Authorize(Roles = "Teacher")]
        [HttpGet]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentOperations.DeleteStudent(id);
                return RedirectToAction("GetAllStudents");
            }
            else
            {
                return View();
            }
        }



        //StoredProcedure 
        //public IActionResult GetIndividualStudent(StudentDetails studentDetails)
        //{
        //    var employees = _studentOperations.GetStudentById(studentDetails.StudendId);
        //    return View(employees);
        //}


        public IActionResult GetIndividualStudent()
        {
            //HttpContext.Session.GetString("Enroll");
            var data = _studentOperations.GetStudentById(HttpContext.Session.GetString("Enroll").ToString());
            return View(data);
        }




    }			
	}

