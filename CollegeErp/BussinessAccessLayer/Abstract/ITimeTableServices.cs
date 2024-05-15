using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
	public interface ITimeTableServices
	{
		public Task<bool> AddTimeTable(TimeTable timetable);
        public Task<IEnumerable<TimeTable>> GetTimeTableDetials();
        public Task<TimeTable> GetTimeTableById(int Id);
        public Task<bool> UpdateTimeTable(TimeTable timeTable);
        public Task<bool> DeleteTimeTable(int Id);

        //Stored Procedure
        public List<TimeTable> GetTimeTable(string EnrollNo);

    }
}
