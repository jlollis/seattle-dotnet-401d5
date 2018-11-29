using BlogPostClassDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Pages.Blog
{

	public class UpdateModel : PageModel
	{
		private BlogDbContext _context;

		[BindProperty]
		public BlogPostClassDemo.Models.Blog Blog { get; set; }

		public UpdateModel(BlogDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> OnGet(int? id)
		{
			if (id == null)
			{
				RedirectToPage("./Index");
			}

			Blog = await _context.Blogs.FirstOrDefaultAsync(x => x.ID == id);

			if (Blog == null)
			{
				RedirectToPage("./Index");
			}
			return Page();
		}

		public async Task<IActionResult> OnPost()
		{
			if(!ModelState.IsValid)
			{
				Page();
			}

			_context.Attach(Blog).State = EntityState.Modified;
			
			var result = _context.Blogs.AnyAsync(b => b.ID == Blog.ID);
			if(result != null)
			{
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
			
		}
	}
}