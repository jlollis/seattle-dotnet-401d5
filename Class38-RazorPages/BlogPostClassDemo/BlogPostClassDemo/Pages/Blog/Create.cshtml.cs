using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostClassDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogPostClassDemo.Pages.Blog
{
    public class CreateModel : PageModel
    {
		private BlogDbContext _context;

		public CreateModel(BlogDbContext context)
		{
			_context = context;
		}

	
		[BindProperty]
		public BlogPostClassDemo.Models.Blog Blog { get; set; }


		public IActionResult OnGet()
        {
			return Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if(!ModelState.IsValid)
			{
				return Page();
			}

			_context.Blogs.Add(Blog);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}


    }
}