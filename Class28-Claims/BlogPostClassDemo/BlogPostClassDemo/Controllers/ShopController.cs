using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostClassDemo.Controllers
{
	[Authorize]
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}