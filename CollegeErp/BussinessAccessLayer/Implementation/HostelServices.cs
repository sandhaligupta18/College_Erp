using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
    public class HostelServices:IHostelServices
    {
        private readonly AppDB_Context _appDBContext;

        public HostelServices(AppDB_Context appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<bool> AddHostelUser(Hostel hostels)
        {
            try
            {
                var ifExist = _appDBContext.Hostels.Where(x => x.EnrollNo == hostels.EnrollNo);
                if (ifExist.Any())
                {
                    return false;
                }
                else
                {
                    Hostel hostel  = new()
                    {
                        StudentName = hostels.StudentName,
                        EnrollNo = hostels.StudentName,
                        HostelName = hostels.HostelName,
                        RoomNo = hostels.RoomNo,
                        AllocationDate = hostels.AllocationDate,
                        IsActive = hostels.IsActive,
                        TotalFee = hostels.TotalFee,                     
                        SubmittedFee = hostels.SubmittedFee,
                        PendingFee = hostels.PendingFee
                    };
                    _appDBContext.Hostels.Add(hostel);
                    var result = await _appDBContext.SaveChangesAsync();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Hostel>> GetHostelDetails()
        {
            try
            {
                var result = await _appDBContext.Hostels.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Hostel> GetHostelUser(string EnrollNo)
        {
            return await _appDBContext.Hostels.FindAsync(EnrollNo);

        }
        public async Task<bool> UpdateHostelDetails(Hostel hostel)
        {

            try
            {
                _appDBContext.Hostels.Update(hostel);
                var result = await _appDBContext.SaveChangesAsync();
                if (result > 0)
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


        public async Task<bool> DeleteHostelUser(string EnrollNo)
        {
            try
            {
                if (_appDBContext.Hostels == null)
                {
                    return false;
                }
                var data = await _appDBContext.Hostels.FindAsync(EnrollNo);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.Hostels.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


		//stored Procedure

		public List<Hostel> GetHostelDetails(string EnrollNo)
		{
			using (_appDBContext)
			{
				return _appDBContext.Hostels.FromSqlRaw<Hostel>("EXEC GetHostelDetail @EnrollNo",

					new SqlParameter("@EnrollNo", EnrollNo)).ToList();
			}
		}


	}
}
