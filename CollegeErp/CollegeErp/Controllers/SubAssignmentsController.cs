using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
    public class SubAssignmentsController : Controller
    {

        private readonly IAssignmentsServices _assignmentsServices;

        public SubAssignmentsController(IAssignmentsServices assignmentsServices)
        {
            _assignmentsServices = assignmentsServices;
        }

        public IActionResult AddAssignments()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAssignments(SubjectAssignmentsView assignmentsViews)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _assignmentsServices.AddAssignments(assignmentsViews);
                    if (result)
                    {


                        return RedirectToAction("AddAssignments");
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
            catch 
            {               
                throw;
            }
        }
		public async Task<IActionResult> GetAllAssign()
		{
			var data = await _assignmentsServices.GetAssignDetails();

			return View(data);
		}

		[HttpGet]
		public async Task<IActionResult> GetAssignById(int Id)
		{
			var data = await _assignmentsServices.GetAssignById(Id);
			return View(data);
		}
		[HttpGet]
		public async Task<IActionResult> UpdateAssignment(int Id)
		{
			var values = await _assignmentsServices.GetAssignById(Id);
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateAssignment(SubjectAssignments subjectAssignments)
		{
			await _assignmentsServices.UpdateAssignment(subjectAssignments);
			return RedirectToAction("GetAllAssign");
		}
        [HttpGet]
        public async Task<IActionResult> DeleteAssignment(int Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _assignmentsServices.DeleteAssignment(Id);
                return RedirectToAction("GetAllAssign");
            }
            else
            {
                return View();
            }
        }
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
