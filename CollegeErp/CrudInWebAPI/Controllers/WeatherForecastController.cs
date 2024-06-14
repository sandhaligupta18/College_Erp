using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace CrudInWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{

		
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly ITeacherOperations _teacherOperations;
		public WeatherForecastController(ILogger<WeatherForecastController> logger , ITeacherOperations teacherOperations)
		{
			_logger = logger;
			_teacherOperations = teacherOperations;
		}


		[HttpPost]
		public async Task<IActionResult> AddTeacher(TeacherDetails teacherDetail)
		{
			try
			{			
					var result = await _teacherOperations.AddTeacher(teacherDetail);
				return Ok("Teacher Added successfully");					
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}
		[HttpPut]
		public async Task<IActionResult> UpdateTeacher(TeacherDetails teacherDetails)
		{
			await _teacherOperations.UpdateTeacher(teacherDetails);
			return Ok("Data Updated Successfully");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteTeacher(string id)
		{
		
				var result = await _teacherOperations.DeleteTeacher(id);
			return Ok("Delete successfully");
			
			
		}







		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
