﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostClassDemo.Models;
using BlogPostClassDemo.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostClassDemo.Controllers
{
    public class AccountController : Controller
    {
		private UserManager<ApplicationUser> _userManager;
		private SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel rvm)
		{
			if(ModelState.IsValid)
			{
				// start the registration process
				ApplicationUser user = new ApplicationUser()
				{
					UserName = rvm.Email,
					Email = rvm.Email,
					FirstName = rvm.FirstName,
					LastName = rvm.LastName, 
					Birthday = rvm.Birthday
				};

				var result = await _userManager.CreateAsync(user, rvm.Password);

				if(result.Succeeded)
				{
					await _signInManager.SignInAsync(user,isPersistent:false);
				}

			}
			return View();
		}
    }
}