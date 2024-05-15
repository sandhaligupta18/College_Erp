using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
    public class FeeController : Controller
    {


        private readonly IFeeStructureServices _feestructureServices;
        public FeeController( IFeeStructureServices feestructureServices)
        {
            _feestructureServices = feestructureServices;

        }
        [HttpGet]
        public IActionResult AddFee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFee(FeeStructure feeStructure)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _feestructureServices.AddFee(feeStructure);
                    if (result)
                    {
                        return RedirectToAction("AddFee");
                    }
                }
                return View();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IActionResult> GetAllFeeDetails()
        {
            var data = await _feestructureServices.GetFeeDetails();

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetFeeById(string Id)
        {
            var data = await _feestructureServices.GetFee(Id);
            return View(data);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateFee(string Id)
        {
            var values = await _feestructureServices.GetFee(Id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFee(FeeStructure feeStructure)
        {
            await _feestructureServices.UpdateFee(feeStructure);
            return RedirectToAction("GetAllFeeDetails");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFee(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _feestructureServices.DeleteFee(id);
                return RedirectToAction("GetAllFeeDetails");
            }
            else
            {
                return View();
            }
        }
        //StoredProcedure

		public IActionResult GetFeeDetail()
		{

			var data = _feestructureServices.GetFeeDetails(HttpContext.Session.GetString("Enroll").ToString());
			return View(data);
		}

	}
}
