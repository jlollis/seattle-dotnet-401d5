using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Models.Handlers
{
	public class RequireEmailRequirement : IAuthorizationRequirement
	{
		public RequireEmailRequirement()
		{

		}
	}
}
