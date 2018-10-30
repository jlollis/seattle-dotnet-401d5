using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEnrollment.Models.Interfaces
{
	public interface IStudent
	{
		Task<IEnumerable<Student>> GetStudents();

		Task UpdateStudent(Student student);

		Task<IEnumerable<Transcript>> GetTranscripts(int studentId);

		Task<bool> DeleteStudent(int id);

		Task CreateStudent(Student student);

		Task<bool> Exists(int id);

		Task<Student> GetStudent(int Id);


	}
}
