using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IF4101_ProjectI.Models.Data
{
    
    public class InquirieDAO : Controller
    {
        
        private readonly IF4101_B91472_B92299Context _context;
        private readonly IConfiguration _configuration;
        string connectionString;
		public InquirieDAO(IConfiguration configuration)
		{
			_configuration = configuration;
			connectionString = _configuration.GetConnectionString("DefaultConnection");

		}

		public InquirieDAO(IF4101_B91472_B92299Context context) //cambien el mio
		{
			_context = context;
		}
		public InquirieDAO()
		{

		}

		public int Insert(Inquirie inq)
		{
			_context.Inquirie.Add(inq);
			_context.SaveChanges();
			return 1;
		}

		public int Update(Inquirie inq)
		{
			var user = _context.Inquirie.First(p => p.Id == inq.Id);

			user.Id = inq.Id;
			user.Inquirie1 = inq.Inquirie1;			
			user.Author = inq.Author;
			user.Professor = inq.Professor;
			user.Type = inq.Type;
			_context.SaveChanges();
			return 1;
		}

		public IEnumerable<Inquirie> GetCoursesEF()
		{

			var inq = _context.Inquirie;

			return inq.ToList();
		}

		public int Delete(int value)
		{
			Inquirie inqDelete = _context.Inquirie
					.Where(Inquirie => Inquirie.Id == value)
					.FirstOrDefault();
			_context.Inquirie.Remove(inqDelete);
			_context.SaveChanges();

			return 1;
		}

	}
}
