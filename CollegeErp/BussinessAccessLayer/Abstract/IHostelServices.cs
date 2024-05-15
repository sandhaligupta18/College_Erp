using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IHostelServices
    {
        public Task<bool> AddHostelUser(Hostel hostel);
        public Task<IEnumerable<Hostel>> GetHostelDetails();
        public Task<bool> UpdateHostelDetails(Hostel hostel);
        public Task<Hostel> GetHostelUser(string EnrollNo);
        public Task<bool> DeleteHostelUser(string EnrollNo);

		//stored Procedure
		public List<Hostel> GetHostelDetails(string EnrollNo);

	}
}
