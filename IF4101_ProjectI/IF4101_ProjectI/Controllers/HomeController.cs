using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models;
using IF4101_ProjectI.Models.Data;
using LabMVC_15042021.Models;
using LabMVC_15042021.Models.Data;
using LabMVC_15042021.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LabMVC_15042021.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		StudentDAO studentDAO;
		
		public HomeController(ILogger<HomeController> logger, IConfiguration configuration) { 
			_logger = logger; 
			_configuration = configuration; 
		}		

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Insert([FromBody] Student student)
		{
			//Llamada viene de la vista, este es el intermediario
			//este método es el que llama al modelo (BD)

			//regla de negocio, simulando que existe e@e.com
			if (student.Email == "" || student.Name == "" || student.Password == "" || student.User == "" || !(student.Email.Contains("@")))
			{
				return Error();
			}
			else
			{
				studentDAO = new StudentDAO(_configuration);
				int resultToReturn = studentDAO.Insert(student);

				return Ok(resultToReturn); //retornamos el 1 o el 0 ala vista
			}
		}

		public IActionResult Get([FromBody] Param param)
		{
				
				studentDAO = new StudentDAO(_configuration);
				bool resultToReturn = studentDAO.Login(param);
				return Ok(resultToReturn);
			
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
