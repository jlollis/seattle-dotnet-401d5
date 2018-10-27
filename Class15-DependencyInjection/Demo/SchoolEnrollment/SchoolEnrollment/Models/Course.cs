using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEnrollment.Models
{
	public class Course
	{
		public int ID { get; set; }
		[Required]
		[Display(Name = "Course Name")]
		public string Name { get; set; }
		[Required]
		[EnumDataType(typeof(Technology))]
		public Technology Technology { get; set; }


		[Required(ErrorMessage ="Please provide a valid price")]
	
		public decimal Price { get; set; }
	}

	public enum Technology
	{
		[Display(Name =".NET")]
		dotnet,
		[Display(Name = "Java")]
		java,
		[Display(Name = "Python")]
		python,
		[Display(Name = ".JavaScript")]
		javascript
	}
}
