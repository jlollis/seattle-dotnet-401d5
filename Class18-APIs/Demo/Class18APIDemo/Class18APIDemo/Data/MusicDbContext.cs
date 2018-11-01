using Class18APIDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class18APIDemo.Data
{
	public class MusicDbContext : DbContext
	{
		public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
		{
		
		}

		public DbSet<Songs> Songs { get; set; }
	}
}
