using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostClassDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostClassDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public void ProcessPayment()
		{
			Payment.RunPayment();
		}

	}
}