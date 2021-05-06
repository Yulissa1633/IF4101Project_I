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
	public class StudentDAO
	{
		private readonly IF4101_B91472_B92299Context _context;
		private readonly IConfiguration _configuration;
		string connectionString;

		public StudentDAO(IConfiguration configuration)
		{
			_configuration = configuration;
			connectionString = _configuration.GetConnectionString("DefaultConnection");

		}

		public StudentDAO(IF4101_B91472_B92299Context context) //cambien el mio
		{
			_context = context;
		}
		public StudentDAO()
		{

		}

		//método que simula la inserción de estudiante em BD
		public int Insert(Domain.Student student)
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

		[JSInvokable]
		public bool Login(Param param)
		{
            Domain.Student s = new Domain.Student();
			using (SqlConnection connection = new SqlConnection(connectionString))
            {
				connection.Open(); //abrimos conexión
				SqlCommand command = new SqlCommand("GetStudent", connection);

				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@User", param.User);
				command.Parameters.AddWithValue("@Password", param.Password);

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())//Obtenemos los datos de la columna y asignamos a los campos de la Cache de Usuario
					{
						s.Id = reader.GetInt32(0);
						s.User = reader.GetString(2);
						s.Name = reader.GetString(1);
						s.Password = reader.GetString(3);
						s.Email = reader.GetString(4);
					}
					return true;
				}
				else
					return false;
			}

		}

		public IEnumerable<Student> GetStudentsEF()
		{
			var students = _context.Students;

			return students.ToList();
		}

	}
}
