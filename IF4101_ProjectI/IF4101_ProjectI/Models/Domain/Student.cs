using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC_15042021.Models.Domain
{
	public class Student
	{
		private string name;
		private string email;
		private string password;

		public Student()
		{
		}

		public Student(string name, string email, string password)
		{
			this.Name = name;
			this.Email = email;
			this.Password = password;
		}

		public string Name { get => name; set => name = value; }
		public string Email { get => email; set => email = value; }
		public string Password { get => password; set => password = value; }
	}
}
