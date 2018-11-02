using Microsoft.AspNetCore.Mvc;
using PlaylistAPI.Data;
using PlaylistAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SongsController : ControllerBase
	{
		private MusicLibraryDbContext _context;

		public SongsController(MusicLibraryDbContext context)
		{
			_context = context;
		}
		public ActionResult<IEnumerable<Songs>> Get()
		{
			return _context.Songs;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<Songs> Get(int id)
		{
			var song = _context.Songs.FirstOrDefault(x => x.ID == id);
			if (song == null)
			{
				return NotFound();
			}

			return Ok(song);
		}

		// POST api/values
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Songs song)
		{
			await _context.Songs.AddAsync(song);
			await _context.SaveChangesAsync();

			return RedirectToAction("Get", new { id = song.ID });
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Songs song)
		{
			var result = _context.Songs.FirstOrDefault(x => x.ID == id);

			if(result != null)
			{
				_context.Songs.Update(song);
			}
			else
			{
				await Post(song);
			}

			return RedirectToAction("Get", new { id = song.ID });
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var result = _context.Songs.FirstOrDefault(x => x.ID == id);

			if(result != null)
			{
				_context.Songs.Remove(result);
			}

			return Ok();
		}
	}
}