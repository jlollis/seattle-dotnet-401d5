using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassDemoStudentEnrollment.Models
{
	public class Transcript
	{
		[Key]
		public int ID { get; set; }

		public int StudentID { get; set; }
		public int CourseID { get; set; }
		public string Grade { get; set; }
		public bool Pass { get; set; }

		public Student Student { get; set; }
		public Course Course { get; set; }


	}
}
