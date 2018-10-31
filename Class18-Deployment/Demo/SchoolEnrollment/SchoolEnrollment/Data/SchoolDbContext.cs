using Microsoft.EntityFrameworkCore;
using SchoolEnrollment.Models;

namespace SchoolEnrollment.Data
{
	public class SchoolDbContext : DbContext
	{
		public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CourseEnrollments>().HasKey(ce => new { ce.CourseID, ce.StudentID });

			modelBuilder.Entity<Student>().HasData(
				new Student
				{
					ID = 1,
					FirstName = "Jack",
					LastName = "Shepard",
					Age = 36
				},
				new Student
				{
					ID = 2,
					FirstName = "Kate",
					LastName = "Austin",
					Age = 34
				},
				new Student
				{
					ID = 3,
					FirstName = "Kanye",
					LastName = "West",
					Age = 40
				}
				);

			modelBuilder.Entity<Course>().HasData(
				new Course
				{
					ID = 1,
					Name = "ethics",
					Technology = Technology.dotnet,
					Price = 350.99m
				},
				new Course
				{
					ID = 2,
					Name = "Advanced Python",
					Technology = Technology.python,
					Price = 300.99m
				},
				new Course
				{
					ID = 43,
					Name = "c sharp",
					Technology = Technology.java,
					Price = 250.99m
				}

				);
		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Student> Student { get; set; }
		public DbSet<CourseEnrollments> CourseEnrollments { get; set; }
		public DbSet<Transcript> Transcript { get; set; }




	}
}
