using ClassDemoStudentEnrollment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassDemoStudentEnrollment.Data
{
	public class EnrollmentDbContext : DbContext
	{
		public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CourseEnrollments>().HasKey(
				ce => new { ce.CourseID, ce.StudentID }
				);
		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Course> Courses { get; set; }
		public DbSet<Transcript> Transcripts { get; set; }
		public DbSet<CourseEnrollments> CourseEnrollments { get; set; }

	}
}
