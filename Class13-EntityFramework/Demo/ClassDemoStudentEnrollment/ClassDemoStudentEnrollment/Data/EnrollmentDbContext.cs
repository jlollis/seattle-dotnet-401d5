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
	}
}
