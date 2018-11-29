using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostClassDemo.Data;
using BlogPostClassDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlogPostClassDemo.Pages.Blog
{
    public class IndexModel : PageModel
    {
		private BlogDbContext _context;

		public IndexModel(BlogDbContext context)
		{
			_context = context;
		}

		public List<BlogPostClassDemo.Models.Blog> Blogs { get; set; }

		public async Task OnGet()
        {
			Blogs = await _context.Blogs.ToListAsync();
        }
    }
}