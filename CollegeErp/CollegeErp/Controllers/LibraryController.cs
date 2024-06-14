using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
    public class LibraryController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ILibraryServices _libraryServices;

        public LibraryController(ILogger<HomeController> logger , ILibraryServices libraryServices)
        {
            _logger = logger;
           _libraryServices = libraryServices;
        }
        public IActionResult AddLibraryUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddLibraryUser(LibraryDetails libraryDetails)
        {
            try
            {
                _logger.LogInformation("Add Library Details  in progress....");
                if (ModelState.IsValid)
                {
                    var result = await _libraryServices.AddLibraryUser(libraryDetails);
                    if (result)
                    {

                        return RedirectToAction("AddLibraryUser");
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

        public async Task<IActionResult> GetAllLibraryDetails()
        {
            var data = await _libraryServices.GetLibraryDetails();

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetLibUserDetail(int Id)
        {
            var data = await _libraryServices.GetLibUserDetail(Id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLibDetails(int Id)
        {
            var values = await _libraryServices.GetLibUserDetail(Id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLibDetails(LibraryDetails libraryDetails)
        {
            await _libraryServices.UpdateLibDetails(libraryDetails);
            return RedirectToAction("GetAllLibraryDetails");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteLibDetails(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _libraryServices.DeleteLibDetails(id);
                return RedirectToAction("GetAllLibraryDetails");
            }
            else
            {
                return View();
            }
        }

        //StoredProcedure
        public IActionResult GetIndividualLibraryDetail()
        {
          
            var data = _libraryServices.GetLibraryDetailsById(HttpContext.Session.GetString("Enroll").ToString());
            return View(data);
        }




    }
}
