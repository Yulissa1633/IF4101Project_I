using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models;
using LabMVC_15042021.Models;
using LabMVC_15042021.Models.Data;
using LabMVC_15042021.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LabMVC_15042021.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
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
			if (student.Email == ""|| student.Name == "" || student.Password == "" || !(student.Email.Contains("@")))
			{
				return Error();
			}
			else
			{

				StudentDAO studentDAO = new StudentDAO();
				studentDAO.Insert(student);

				return Ok();
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
