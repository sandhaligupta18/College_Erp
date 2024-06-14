using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
    public class LibraryServices :ILibraryServices
    {
        private readonly AppDB_Context _appDBContext;
        public LibraryServices(AppDB_Context appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<bool> AddLibraryUser(LibraryDetails libraryDetails)
        {
            try
            {
                var ifExist = _appDBContext.LibraryData.Where(x => x.id == libraryDetails.id);
                if (ifExist.Any())
                {
                    return false;
                }
                else
                {
                    LibraryDetails libraryDetail = new()
                    {
                        IssuedBy = libraryDetails.IssuedBy,
                        EnrollNo= libraryDetails.EnrollNo,
                        BookId= libraryDetails.BookId,
                        BookName = libraryDetails.BookName,
                        IssuedOn= libraryDetails.IssuedOn,
                        ReturnDate = libraryDetails.ReturnDate

                    };
                    _appDBContext.LibraryData.Add(libraryDetail);
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

        public async Task<IEnumerable<LibraryDetails>> GetLibraryDetails()
        {
            try
            {
                var result = await _appDBContext.LibraryData.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LibraryDetails> GetLibUserDetail(int id)
        {
            return await _appDBContext.LibraryData.FindAsync(id);

        }
        public async Task<bool> UpdateLibDetails(LibraryDetails libraryDetails)
        {

            try
            {
                _appDBContext.LibraryData.Update(libraryDetails);
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


        public async Task<bool> DeleteLibDetails(int id)
        {
            try
            {
                if (_appDBContext.LibraryData == null)
                {
                    return false;
                }
                var data = await _appDBContext.LibraryData.FindAsync(id);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.LibraryData.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //stored Procedure

        public List<LibraryDetails> GetLibraryDetailsById(string EnrollNo)
        {
            using (_appDBContext)
            {
                return _appDBContext.LibraryData.FromSqlRaw<LibraryDetails>("EXEC LibraryDataByEnroll @EnrollNo",

                    new SqlParameter("@EnrollNo", EnrollNo)).ToList();
            }
        }


    }
}
