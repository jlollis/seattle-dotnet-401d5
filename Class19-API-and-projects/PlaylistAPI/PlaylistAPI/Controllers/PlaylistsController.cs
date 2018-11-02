using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistAPI.Data;
using PlaylistAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlaylistsController : ControllerBase
	{
		private MusicLibraryDbContext _context;

		public PlaylistsController(MusicLibraryDbContext context)
		{
			_context = context;
		}
		public ActionResult<IEnumerable<Playlists>> Get()
		{
			return _context.Playlists;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<Songs> Get(int id)
		{
			var playlist = _context.Playlists.FirstOrDefault(x => x.ID == id);

			if (playlist == null)
			{
				return NotFound();
			}

			playlist.Songs = _context.Songs.Where(p => p.PlaylistID == playlist.ID).ToList();

			return Ok(playlist);
		}

		// POST api/values
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Playlists playlist)
		{
			await _context.Playlists.AddAsync(playlist);
			await _context.SaveChangesAsync();

			foreach (var item in playlist.Songs)
			{
				item.PlaylistID = playlist.ID;
			}

			await _context.SaveChangesAsync();

			return RedirectToAction("Get", new { id = playlist.ID });
		}

		//// PUT api/values/5
		//[HttpPut("{id}")]
		//public async Task<IActionResult> Put(int id, [FromBody] Songs song)
		//{
		
		//}

		//// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public IActionResult Delete(int id)
		//{
			
		//}
	}
}