using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ModelAccessLayer;

namespace CollegeErp.Controllers
{
	public class AccountController : Controller
	{
        private readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(Register user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountServices.CreateUser(user);
                    if (result)
                    {
                        return RedirectToAction("Loginusers");
                    }
                }
                return View();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegisterUsers()
        {
            var data = await _accountServices.GetAllUsers();

            return View(data);
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = await _accountServices.CreateRole(role);
                    if (data)
                    {
                        return RedirectToAction("CreateRole");
                    }
                }
                return View();

            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult Loginusers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Loginusers(LoginUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountServices.Loginusers(user);
                    
					  HttpContext.Session.SetString( "Enroll", user.UniqueValue);
                    //HttpContext.Session.SetString("TeacherID", user.TeacherId);
					if (result)
                    {
                            return RedirectToAction("Index", "Home");                       
                    }
                }
                return View();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult SetNewPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SetNewPassword(string Email, string newPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var result=  await _accountServices.SetNewPassword(Email,newPassword);
                    if (result)
                    {
                        return RedirectToAction("Loginusers");
                    }
                }
                return View();
            }
            catch 
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  ResetPassword( SetNewPassword setNewPassword)
        {
			try
			{
				if (ModelState.IsValid)
                {
					var result = await _accountServices.ResetPassword(setNewPassword);
                    if(result)
                    {
						return RedirectToAction("Loginusers");
					}
				}
                return View();
            }
            catch
            {
                throw;
            }

        }
    }
}
