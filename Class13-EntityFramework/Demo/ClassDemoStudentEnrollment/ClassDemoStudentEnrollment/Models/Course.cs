using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassDemoStudentEnrollment.Models
{
	public class Course
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public Technology Technology { get; set; }
		public decimal Price { get; set; }

		public ICollection<CourseEnrollments> Enrollments { get; set; }

		public ICollection<Transcript> Transcripts { get; set; }
	}

	public enum Technology
	{
		dotnet,
		python,
		java,
		javascript
	}
}
