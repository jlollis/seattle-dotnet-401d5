using System;
using Xunit;
using SchoolEnrollment;
using SchoolEnrollment.Data;
using Microsoft.EntityFrameworkCore;
using SchoolEnrollment.Models;
using System.Linq;

namespace XUnitTestProject1
{
	public class UnitTest1
	{
		[Fact]
		public void CanGetCourseName()
		{
			Course course = new Course();
			course.Name = "MyCourse";

			Assert.Equal("MyCourse", course.Name);

		}

		[Fact]
		public void SetCourseName()
		{
			Course course = new Course();
			course.Name = "Potions";
			course.Technology = Technology.python;
			course.Price = 500m;


			// Act 
			course.Name = "Python";

			Assert.Equal("Python", course.Name);
		

		}

		[Fact]
		public async void SaveCourseInDb()
		{
			DbContextOptions<SchoolDbContext> options =
			new DbContextOptionsBuilder<SchoolDbContext>()
			.UseInMemoryDatabase("GetCourseName")
			.Options;


			// Act
			// creating a variable that "gets" the name

			using (SchoolDbContext context = new SchoolDbContext(options))
			{
				//Arrange
				Course course = new Course();
				course.Name = "MyCourse";
				course.Technology = Technology.dotnet;
				course.Price = 300m;

				context.Courses.Add(course);
				context.SaveChanges();

				//// Act
				var courseName = await context.Courses.FirstOrDefaultAsync(x => x.Name == course.Name);

				// Assert
				Assert.Equal("MyCourse", courseName.Name);


			}

		}
	}
}
