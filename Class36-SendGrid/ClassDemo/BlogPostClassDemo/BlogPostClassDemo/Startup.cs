using BlogPostClassDemo.Data;
using BlogPostClassDemo.Models;
using BlogPostClassDemo.Models.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogPostClassDemo
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			var builder = new ConfigurationBuilder().AddEnvironmentVariables();
			builder.AddUserSecrets<Startup>();
			Configuration = builder.Build();
			//Configuration = configuration;

		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 3;
				options.Password.RequireLowercase = true;
			}

			)
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddDbContext<BlogDbContext>(options =>
			options.UseSqlServer(Configuration["ConnectionStrings:ProductionBlog"]));

			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(Configuration["ConnectionStrings:Productionidentity"]));


			services.AddAuthorization(options =>
		   {
			   options.AddPolicy("AdminOnly", policy => policy.RequireRole(UserRoles.Admin));
			   options.AddPolicy("FavoriteColor", policy => policy.RequireClaim("FavoriteColor"));
			   options.AddPolicy("Over18Only", policy => policy.Requirements.Add(new MinimumAgeRequirement(18)));
			   options.AddPolicy("EmailPolicy", policy => policy.Requirements.Add(new RequireEmailRequirement()));
		   });


			services.AddScoped<IAuthorizationHandler, CodeFellowsEmailHandler>();
			services.AddScoped<IAuthorizationHandler, EduEmailRequirement>();
			services.AddScoped<IEmailSender, EmailSender>();


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthentication();

			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
