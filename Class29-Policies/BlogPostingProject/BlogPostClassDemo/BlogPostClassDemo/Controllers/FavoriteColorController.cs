using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostClassDemo.Controllers
{
	[Authorize(Policy ="FavoriteColor")]
    public class FavoriteColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}