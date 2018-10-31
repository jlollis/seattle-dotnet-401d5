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

		public async Task CreateStudent(Student student)
		{
			_context.Student.Add(student);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> DeleteStudent(int id)
		{
			Student student = await GetStudent(id);
			var result = _context.Student.Remove(student);
			await _context.SaveChangesAsync();
			student = await GetStudent(id);
			if (student == null)
			{
				return true;
			}

			return false;


		}

		public Task<bool> Exists(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Student> GetStudent(int id)
		{
			return await _context.Student.FirstOrDefaultAsync(student => student.ID == id);

		}

		/// <summary>
		/// Get All Students in DB
		/// </summary>
		/// <returns>List of All Students</returns>
		public async Task<IEnumerable<Student>> GetStudents()
		{
			return await _context.Student.ToListAsync();
		}

		public IEnumerable<Transcript> GetTranscripts(int studentId)
		{
			var studentTranscripts = _context.Transcript
			.Where(x => x.StudentID == studentId)
			.Include(c => c.Course)
			.Include(c => c.Student);

			return studentTranscripts;
		}

		public async Task UpdateStudent(Student student)
		{
			_context.Student.Update(student);
			await _context.SaveChangesAsync();
		}
	}
}
