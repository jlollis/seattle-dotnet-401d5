﻿using BlogPostClassDemo.Models;
using BlogPostClassDemo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Controllers
{
	[AllowAnonymous]
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
			if (ModelState.IsValid)
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

				if (result.Succeeded)
				{
					// Custom Claim type for full name
					Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

					// claim type for birthday
					Claim birthdayClaim = new Claim(
						ClaimTypes.DateOfBirth, 
						new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);

					// claim type for email
					Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

					List<Claim> myclaims = new List<Claim>()
					{
						fullNameClaim,
						birthdayClaim,
						emailClaim
					};					;

					//myclaims.Add(fullNameClaim);
					//myclaims.Add(birthdayClaim);
					//myclaims.Add(emailClaim);


					//await _userManager.AddClaimAsync(user, fullNameClaim);

					await _userManager.AddClaimsAsync(user, myclaims);

					

					await _signInManager.SignInAsync(user, isPersistent: false);

					return RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}


			}

			return View(rvm);
		}


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel lvm)
		{
			// default username: octo@cat.com
			// password: @Cat123!
			if(ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Your are wrong");
				}


			}

			return View(lvm);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}