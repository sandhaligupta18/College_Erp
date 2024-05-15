using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
    public class TimeTableController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ITimeTableServices _timeTableServices;

        public TimeTableController(ILogger<HomeController> logger, ITimeTableServices timeTableServices)
        {
            _logger = logger;
            _timeTableServices = timeTableServices;
        }

        //[Authorize(Roles = "Teacher")]
        public IActionResult AddTimeTable()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTimeTable(TimeTable timetable)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _timeTableServices.AddTimeTable(timetable);
                    if (result)
                    {


                        return RedirectToAction("AddTimeTable");
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

        public async Task<IActionResult> GetAllTimeTable()
        {
            var data = await _timeTableServices.GetTimeTableDetials();

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetTimeTableById(int Id)
        {
            var data = await _timeTableServices.GetTimeTableById(Id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTimeTable(int Id)
        {
            var values = await _timeTableServices.GetTimeTableById(Id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTimeTable(TimeTable timeTable)
        {
            await _timeTableServices.UpdateTimeTable(timeTable);
            return RedirectToAction("GetAllTimeTable");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTimeTable(int Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _timeTableServices.DeleteTimeTable(Id);
                return RedirectToAction("GetAllTimeTable");
            }
            else
            {
                return View();
            }
        }


        //Stored Procedure
        public IActionResult GetIndividualTimeTable()
        {
            //HttpContext.Session.GetString("Enroll");
            var data = _timeTableServices.GetTimeTable(HttpContext.Session.GetString("Enroll").ToString());
            return View(data);
        }

    }
}
