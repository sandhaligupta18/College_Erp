using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
    public class HostelController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IHostelServices _hostelServices;

        public HostelController(ILogger<HomeController> logger, IHostelServices hostelServices)
        {
            _logger = logger;
       _hostelServices = hostelServices;
        }
        public IActionResult AddHostelUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHostelUser( Hostel hostel )
        {
            try
            {
                _logger.LogInformation("Add Hostel Details in progress....");
                if (ModelState.IsValid)
                {
                    var result = await _hostelServices.AddHostelUser(hostel);
                    if (result)
                    {

                        return RedirectToAction("AddHostelUser");
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
        public async Task<IActionResult> GetAllHostelDetails()
        {
            var data = await _hostelServices.GetHostelDetails();

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetHostelUser(string Id)
        {
            var data = await _hostelServices.GetHostelUser(Id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHostelDetails(string Id)
        {
            var values = await _hostelServices.GetHostelUser(Id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHostelDetails(Hostel hostel)
        {
            
            await _hostelServices.UpdateHostelDetails(hostel);
            return RedirectToAction("GetAllHostelDetails");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteHostelUser(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _hostelServices.DeleteHostelUser(id);
                return RedirectToAction("GetAllHostelDetails");
            }
            else
            {
                return View();
            }
        }

		//StoredProcedure
		public IActionResult GetIndividualHostelDetail()
		{
			var data = _hostelServices.GetHostelDetails(HttpContext.Session.GetString("Enroll").ToString());
			return View(data);
		}
	}
}
