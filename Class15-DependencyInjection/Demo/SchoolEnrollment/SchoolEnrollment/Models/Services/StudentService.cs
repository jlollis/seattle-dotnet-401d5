using Microsoft.EntityFrameworkCore;
using SchoolEnrollment.Data;
using SchoolEnrollment.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEnrollment.Models.Services
{
	public class StudentService : IStudent
	{
		private SchoolDbContext _context;

		public StudentService(SchoolDbContext context)
		{
			_context = context;
		}
		public async Task<List<Student>> GetStudents()
		{
			return await _context.Student.ToListAsync();
		}
	}
}
