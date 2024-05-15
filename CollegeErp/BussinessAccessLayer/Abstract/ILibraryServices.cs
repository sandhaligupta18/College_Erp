using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface ILibraryServices
    {
        public Task<bool> AddLibraryUser(LibraryDetails libraryDetails);
        public Task<IEnumerable<LibraryDetails>> GetLibraryDetails();
        public Task<bool> UpdateLibDetails(LibraryDetails libraryDetails);
        public Task<LibraryDetails> GetLibUserDetail(string EnrollNo);
        public Task<bool> DeleteLibDetails(string EnrollNo);

        //stored Procedure
        public List<LibraryDetails> GetLibraryDetailsById(string EnrollNo);


    }
}
