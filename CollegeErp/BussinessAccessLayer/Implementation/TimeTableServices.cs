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
	public class TimeTableServices :ITimeTableServices
	{
		private readonly AppDB_Context _appDBContext;
		public TimeTableServices(AppDB_Context appDBContext)
		{
			_appDBContext = appDBContext;
		}

		public async Task<bool> AddTimeTable(TimeTable timetable)
		{
			try
			{
				var ifExist = _appDBContext.TimeTables.Where(x => x.SubjectId == timetable.SubjectId);
				if (ifExist.Any())
				{
					return false;
				}
				else
				{
					TimeTable time = new()
					{
						TeacherId = timetable.TeacherId,
						SubjectId = timetable.SubjectId,
						Days = timetable.Days,
						Branch = timetable.Branch,
						StartLecture = timetable.StartLecture,
						EndLecture = timetable.EndLecture,
					};
					_appDBContext.TimeTables.Add(time);
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

        public async Task<IEnumerable<TimeTable>> GetTimeTableDetials()
        {
            try
            {
                var result = await _appDBContext.TimeTables.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TimeTable> GetTimeTableById(int Id)
        {
            return await _appDBContext.TimeTables.FindAsync(Id);

        }
        public async Task<bool> UpdateTimeTable(TimeTable timeTable)
        {

            try
            {
                _appDBContext.TimeTables.Update(timeTable);
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


        public async Task<bool> DeleteTimeTable(int Id)
        {
            try
            {
                if (_appDBContext.TimeTables == null)
                {
                    return false;
                }
                var data = await _appDBContext.TimeTables.FindAsync(Id);
                if (data == null)
                {
                    return false;
                }
                _appDBContext.TimeTables.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<TimeTable> GetTimeTable(string EnrollNo)
        {
            using (_appDBContext)
            {
                return _appDBContext.TimeTables.FromSqlRaw<TimeTable>("EXEC GetTimeTable @EnrollNo",

                    new SqlParameter("@EnrollNo", EnrollNo)).ToList();
            }
        }



    }
}
