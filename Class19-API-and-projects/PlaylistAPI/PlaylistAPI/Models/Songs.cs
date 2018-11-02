using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistAPI.Models
{
	public class Songs
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Artist { get; set; }

		public int PlaylistID { get; set; }

	

	}
}
