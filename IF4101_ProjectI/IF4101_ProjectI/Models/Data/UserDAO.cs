using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models.Data;
using IF4101_ProjectI.Models.Entities;
using LabMVC_15042021.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Student = IF4101_ProjectI.Models.Entities.Student;

namespace LabMVC_15042021.Models.Data
{
	public class UserDAO
	{
		private readonly IF4101_B91472_B92299Context _context;
		private readonly IConfiguration _configuration;
		string connectionString;

		public UserDAO(IConfiguration configuration)
		{
			_configuration = configuration;
			connectionString = _configuration.GetConnectionString("DefaultConnection");

		}

		public UserDAO(IF4101_B91472_B92299Context context) //cambien el mio
		{
			_context = context;
		}
		public UserDAO()
		{

		}

		public IEnumerable<UserProfile> GetUsersEF()
		{
			
			var user = _context.UserProfiles;

			return user.ToList();
		}

	}
}
