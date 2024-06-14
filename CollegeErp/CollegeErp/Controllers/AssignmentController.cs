using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAssignmentServicescs _assignmentServicescs;
        public AssignmentController(IAssignmentServicescs assignmentServicescs, ILogger<HomeController> logger)
        {
            _assignmentServicescs = assignmentServicescs;
            _logger = logger;
        }

        public IActionResult AddAssignment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAssignment(AssignmentViews assignmentViews)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _assignmentServicescs.AddAssignment(assignmentViews);
                    if (result)
                    {


                        return RedirectToAction("AddAssignment");
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

        


        public async Task<IActionResult> GetAllAssignment()
        {
            var data = await _assignmentServicescs.GetAssignmentDetails();
            return View(data);
        }

        //[Authorize(Roles = "Teacher , Student")]
        [HttpGet]
        public async Task<IActionResult> GetAssignment(int AssignId)
        {
            var data = await _assignmentServicescs.GetAssignment(AssignId);
            return View(data);
        }

        //[HttpGet]
        //public async Task<IActionResult> UpdateAssignment(string SubjectId)
        //{
        //    var values = await _assignmentServicescs.GetAssignment(SubjectId);
        //    return View(values);
        //}

        //[Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task<IActionResult> UpdateAssignment(Assignment assignment)
        {
            await _assignmentServicescs.UpdateAssignment(assignment);
            return RedirectToAction("GetAllAssignment");
        }

        //[Authorize(Roles = "Teacher")]
        [HttpGet]
        public async Task<IActionResult> DeleteAssignment(string SubjectId)
        {
            if (ModelState.IsValid)
            {
                var result = await _assignmentServicescs.DeleteAssignment(SubjectId);
                return RedirectToAction("GetAllAssignment");
            }
            else
            {
                return View();
            }
        }



    }
}
