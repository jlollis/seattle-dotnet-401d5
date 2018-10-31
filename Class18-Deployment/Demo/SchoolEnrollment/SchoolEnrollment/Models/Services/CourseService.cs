using Microsoft.EntityFrameworkCore;
using SchoolEnrollment.Data;
using SchoolEnrollment.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEnrollment.Models.Services
{
	public class CourseService : ICourse
	{
		private SchoolDbContext _context;

		public CourseService(SchoolDbContext context)
		{
			_context = context;
		}
		public async Task CreateCourse(Course course)
		{
			_context.Courses.Add(course);
			await _context.SaveChangesAsync();

		}

		public async Task DeleteCourse(int id)
		{
			Course course = await GetCourse(id);
			_context.Courses.Remove(course);
			await _context.SaveChangesAsync();
		}

		public async Task<Course> GetCourse(int? id)
		{
			return await _context.Courses.FirstOrDefaultAsync(x => x.ID == id);
		}

		public async Task<List<Course>> GetCourses()
		{
			return await _context.Courses.ToListAsync();
		}

		public IEnumerable<CourseEnrollments> GetEnrollmentsByCourse(int courseId)
		{
			var courseEnrollments = _context.CourseEnrollments
				.Where(x => x.CourseID == courseId)
				.Include(c => c.Course)
				.Include(c => c.Student);

			return courseEnrollments;
		}

		public async Task UpdateCourse(Course course)
		{
			_context.Courses.Update(course);
			await _context.SaveChangesAsync();
		}


	}
}
