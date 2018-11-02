using Microsoft.EntityFrameworkCore;
using PlaylistAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistAPI.Data
{
	public class MusicLibraryDbContext : DbContext
	{
		public MusicLibraryDbContext(DbContextOptions<MusicLibraryDbContext> options) : base(options)
		{

		}

		public DbSet<Songs> Songs { get; set; }
		public DbSet<Playlists> Playlists {get; set;}
	}
}
