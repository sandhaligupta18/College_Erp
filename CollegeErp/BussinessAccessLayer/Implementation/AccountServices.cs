using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
    public class AccountServices:IAccountServices
    {
        private readonly UserManager<RegisterUser> _userManager;
        private readonly SignInManager<RegisterUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDB_Context _appDBContext;
        public AccountServices(UserManager<RegisterUser> userManager , SignInManager<RegisterUser> signInManager , RoleManager<IdentityRole> roleManager , AppDB_Context appDBContext)
        {
            _appDBContext = appDBContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateUser(Register user)
        {
            try
            {
                var users = new RegisterUser
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.FirstName + user.LastName.ToLower(),
                    Address = user.Address,
                    Email = user.Email,
                    RegisterAs = user.RegisterAs,
                    PhoneNumber = user.PhoneNumber,
                    PasswordHash = user.Password
                };
                var result = await _userManager.CreateAsync(users, user.Password);
                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync(user.RegisterAs);
                    if (roleExists)
                    {
                        IdentityResult results = await _userManager.AddToRoleAsync(users, user.RegisterAs);
                    }
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

        public async Task<IEnumerable<RegisterUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
        public async Task<bool> CreateRole(UserRole role)
        {
            try
            {
                IdentityRole roles = new IdentityRole()
                {
                    Name = role.RoleName
                };
                var result = await _roleManager.CreateAsync(roles);
                if (result.Succeeded)
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
        public async Task<bool> Loginusers(LoginUser users)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(users.Email);
                if (user != null)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, users.Password, false, false);                  

					if (signInResult.Succeeded)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SetNewPassword(string Email, string newPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
                    if (result.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }   
        }
		public async Task<bool> ResetPassword(SetNewPassword setNewPassword)
        {
            try { 


                var user = await _userManager.FindByEmailAsync(setNewPassword.Email);
              if(user!= null)
                {
					var token = await _userManager.GeneratePasswordResetTokenAsync(user);
					var result = await _userManager.ResetPasswordAsync(user,token, setNewPassword.NewPassword);
                    if (result.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
				}
                return true;

            }
            catch
            {
                throw;
            }

        }


        //public List<StudentDetails> GetStudentById(string EnrollNo)
        //{
        //    using (_appDBContext)
        //    {
        //        return _appDBContext.StudentData.FromSqlRaw<StudentDetails>("EXEC StudentById @EnrollNo",

        //            new SqlParameter("@EnrollNo", EnrollNo)).ToList();
        //    }
        //}



    }
}
