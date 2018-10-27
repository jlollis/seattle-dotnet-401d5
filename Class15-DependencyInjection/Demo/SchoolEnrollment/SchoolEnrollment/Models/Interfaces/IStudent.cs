using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEnrollment.Models.Interfaces
{
	public interface IStudent
	{
		Task<List<Student>> GetStudents();
	}
}
