using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IFeeStructureServices
    {
        public Task<bool> AddFee(FeeStructure feeStructure);
        public Task<IEnumerable<FeeStructure>> GetFeeDetails();
        public Task<bool> UpdateFee(FeeStructure feeStructure);
        public Task<FeeStructure> GetFee( string EnrollNo);
        public Task<bool> DeleteFee(string EnrollNo);

        //StoredProcedure
		public List<FeeStructure> GetFeeDetails(string EnrollNo);

	}
}
