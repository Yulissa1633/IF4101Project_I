using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LabMVC_15042021.Models.Domain;
using Microsoft.Extensions.Configuration;

namespace LabMVC_15042021.Models.Data
{
	public class StudentDAO
	{
		private readonly IConfiguration _configuration;
		string connectionString;

		public StudentDAO(IConfiguration configuration)
		{
			_configuration = configuration;
			connectionString = _configuration.GetConnectionString("DefaultConnection");

		}
		public StudentDAO() {

		}

		//método que simula la inserción de estudiante em BD
		public int Insert(Student student)
		{
			int resultToReturn;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open(); //abrimos conexión
				SqlCommand command = new SqlCommand("InsertStudent", connection);

				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Name", student.Name);
				command.Parameters.AddWithValue("@Email", student.Email);
				command.Parameters.AddWithValue("@Password", student.Password);
				command.Parameters.AddWithValue("@User", student.User);

				resultToReturn = command.ExecuteNonQuery();
				connection.Close();
			}
			return resultToReturn;
		}
	}
}
