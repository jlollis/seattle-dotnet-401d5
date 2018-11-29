using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Models.Handlers
{
	public class MinimumAgeRequirement : AuthorizationHandler<MinimumAgeRequirement>, IAuthorizationRequirement
	{
		int _minimumAge;
		public MinimumAgeRequirement(int minimumAge)
		{
			_minimumAge = minimumAge;
		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
		{
			if(!context.User.HasClaim(birthday => birthday.Type == ClaimTypes.DateOfBirth))
			{
				return Task.CompletedTask;
			}

			var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(b => b.Type == ClaimTypes.DateOfBirth).Value);

			int calAge = DateTime.Today.Year - dateOfBirth.Year;

			if(dateOfBirth > DateTime.Today.AddYears(-calAge))
			{
				calAge--;
			}

			if(calAge >= _minimumAge)
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}
