using Class18APIDemo.Data;
using Class18APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Class18APIDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SongsController : ControllerBase
	{
		private MusicDbContext _context;

		public SongsController(MusicDbContext context)
		{
			_context = context;
		}

		// Get 
		[HttpGet]
		public async Task<IEnumerable<Songs>> Get()
		{
			return await _context.Songs.ToListAsync();
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute]int id)
		{
			var song = await _context.Songs.FirstOrDefaultAsync(s => s.ID == id);
			if (song == null)
			{
				return NotFound();
			}

			return Ok(song);
		}

		// Post
		[HttpPost]
		public async Task<IActionResult> Post([FromBody]Songs song)
		{
			await _context.Songs.AddAsync(song);
			await _context.SaveChangesAsync();

			//return CreatedAtRoute("Get", new { id = song.ID }, song);

			return RedirectToAction("Get", new { id = song.ID});

		}

		// Put

		// Delete (DESTROY!!!)
	}
}