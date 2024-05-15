using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
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
    public class FeeStructureServices:IFeeStructureServices
    {
        private readonly AppDB_Context _appDBContext;

        public FeeStructureServices(AppDB_Context appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<bool> AddFee(FeeStructure feeStructure)
        {
            try
            {
                var ifExist = _appDBContext.FeeStructures.Where(x => x.EnrollNo == feeStructure.EnrollNo);
                if (ifExist.Any())
                {
                    return false;
                }
                else
                {
                    FeeStructure feeStructures = new()
                    {
                        StudentName = feeStructure.StudentName,
                        EnrollNo= feeStructure.EnrollNo,
                        Course= feeStructure.Course,
                        Branch= feeStructure.Branch,
                        ConcessionDiscount = feeStructure.ConcessionDiscount,
                        TotalFees = feeStructure.TotalFees,
                        SubmittedFees = feeStructure.SubmittedFees,
                        PendingFees = feeStructure.PendingFees
                    };
                    _appDBContext.FeeStructures.Add(feeStructures);
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
            catch {
                throw;

                    }
        }

        public async Task<IEnumerable<FeeStructure>> GetFeeDetails()
        {
            try
            {
                var result = await _appDBContext.FeeStructures.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FeeStructure> GetFee(string EnrollNo)
        {
            return await _appDBContext.FeeStructures.FindAsync(EnrollNo);

        }


        public async Task<bool> UpdateFee(FeeStructure feeStructure)
        {

            try
            {
                _appDBContext.FeeStructures.Update(feeStructure);
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
        public async Task<bool> DeleteFee(string EnrollNo)
        {
            try
            {
                if (_appDBContext.FeeStructures == null)
                {
                    return false;
                }
                var data = await _appDBContext.FeeStructures.FindAsync(EnrollNo);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.FeeStructures.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

		//stored Procedure

		public List<FeeStructure> GetFeeDetails(string EnrollNo)
		{
			using (_appDBContext)
			{
				return _appDBContext.FeeStructures.FromSqlRaw<FeeStructure>("EXEC GetFeeDetails @EnrollNo",

					new SqlParameter("@EnrollNo", EnrollNo)).ToList();
			}
		}


	}
}
