using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IAccountServices
    {
        public Task<bool> CreateUser(Register user);
        public Task<IEnumerable<RegisterUser>> GetAllUsers();
        public Task<bool> CreateRole(UserRole role);
        public Task<bool> Loginusers(LoginUser user);
        public Task<bool> SetNewPassword(string userId, string newPassword);
        public Task<bool> ResetPassword(SetNewPassword setNewPassword);
        public Task<bool> LogoutUser();
        //stored procedure
        //public List<StudentDetails> GetStudentById(string EnrollNo);


    }
}
