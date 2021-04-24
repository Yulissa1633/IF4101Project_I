using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabMVC_15042021.Models.Domain;

namespace LabMVC_15042021.Models.Data
{
	public class StudentDAO
	{
		//método que simula la inserción de estudiante em BD
		public void Insert(Student student)
		{
			List<Student> students = new List<Student>();
			students.Add(student);
		}
	}
}
