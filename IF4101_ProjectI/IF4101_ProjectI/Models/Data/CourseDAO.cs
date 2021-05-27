using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace IF4101_ProjectI.Models.Data
{
    public class CourseDAO
    {
		private readonly IF4101_B91472_B92299Context _context;
		private readonly IConfiguration _configuration;
		string connectionString;

		public CourseDAO(IConfiguration configuration)
		{
			_configuration = configuration;
			connectionString = _configuration.GetConnectionString("DefaultConnection");

		}

		public CourseDAO(IF4101_B91472_B92299Context context) //cambien el mio
		{
			_context = context;
		}
		public CourseDAO()
		{

		}

		public int Insert(Course course)
		{
			_context.Course.Add(course);
			_context.SaveChanges();
			return 1;
		}

        public int Update(UserProfile userp2)
		{
			var user = _context.UserProfile.First(p => p.User == userp2.User);

			user.User = userp2.User;
			user.Name = userp2.Name;
			user.Email = userp2.Email;
			user.Date = userp2.Date;
			user.Image = userp2.Image;
			user.Gender = userp2.Gender;
			_context.SaveChanges();
			return 1;
		}

		public UserProfile GetUserProfile(string userp)
		{

			UserProfile user = _context.UserProfile.First(p => p.User == userp);

			return user;
		}

		public IEnumerable<Course> GetCoursesEF()
		{

			var course = _context.Course;

			return course.ToList();
		}

		public int Delete(string value)
		{
			Course courseDelete = _context.Course
					.Where(Course => Course.Id == value)
					.FirstOrDefault(); 
			_context.Course.Remove(courseDelete);
			_context.SaveChanges();   

			return 1;
		}

		
	}
}
