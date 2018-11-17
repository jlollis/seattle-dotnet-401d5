using BlogPostClassDemo.Data;
using BlogPostClassDemo.Models;
using BlogPostClassDemo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private UserManager<ApplicationUser> _userManager;
		private SignInManager<ApplicationUser> _signInManager;
		private ApplicationDbContext _context;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
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
				CheckUserRolesExist();

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

					Claim favoriteColor = new Claim("FavoriteColor", "red");

					List<Claim> myclaims = new List<Claim>()
					{
						fullNameClaim,
						birthdayClaim,
						emailClaim,
						favoriteColor
					}; 

					//myclaims.Add(fullNameClaim);
					//myclaims.Add(birthdayClaim);
					//myclaims.Add(emailClaim);

					if (rvm.Email == "amanda@codefellows.com")
					{


						await _userManager.AddToRoleAsync(user, UserRoles.Admin);

					}

					await _userManager.AddToRoleAsync(user, UserRoles.Member);

					await _userManager.AddClaimAsync(user, fullNameClaim);

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
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

				if (result.Succeeded)
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

		public void CheckUserRolesExist()
		{
			if (!_context.Roles.Any())
			{
				List<IdentityRole> Roles = new List<IdentityRole>
				{
					new IdentityRole{Name = UserRoles.Admin, NormalizedName=UserRoles.Admin.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString()},
					new IdentityRole{Name = UserRoles.Member, NormalizedName=UserRoles.Member.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString()},
				};

				foreach (var role in Roles)
				{
					_context.Roles.Add(role);
					_context.SaveChanges();
				}
			}
		}
	}
}