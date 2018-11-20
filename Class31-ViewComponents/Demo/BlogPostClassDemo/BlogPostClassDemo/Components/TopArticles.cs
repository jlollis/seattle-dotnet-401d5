using BlogPostClassDemo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Components
{
	
	public class TopArticles : ViewComponent
	{
		private BlogDbContext _context;

		public TopArticles(BlogDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync(int number)
		{
			var blogs = _context.Blogs.OrderByDescending(n => n.ID)
						.Take(number)
						.ToList();

			return View(blogs);

		}



	}
}
