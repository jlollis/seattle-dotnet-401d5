using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistAPI.Models
{
	public class Playlists
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public List<Songs> Songs { get; set; }

	}
}
