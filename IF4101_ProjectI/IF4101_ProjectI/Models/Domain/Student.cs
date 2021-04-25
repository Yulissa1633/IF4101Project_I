using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC_15042021.Models.Domain
{
	public class Student
	{
		private int id;
		private string name;
		private string email;
		private string password;
		private string user;

		public Student()
		{
		}

		public Student(int id, string name, string email, string password, string user)
		{
			this.Name = name;
			this.Email = email;
			this.Password = password;
			this.User = user;
			this.id = id;
		}

		public int Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public string Email { get => email; set => email = value; }
		public string Password { get => password; set => password = value; }
		public string User { get => user; set => user = value; }
	}
}
