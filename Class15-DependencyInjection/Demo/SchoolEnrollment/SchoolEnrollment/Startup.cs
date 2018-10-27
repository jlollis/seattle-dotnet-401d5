using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolEnrollment.Data;
using SchoolEnrollment.Models.Interfaces;
using SchoolEnrollment.Models.Services;

namespace SchoolEnrollment
{
	public class Startup
	{

		public IConfiguration Configuration { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddDbContext<SchoolDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
			);

			services.AddTransient<ICourse, CourseService>();


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc(route =>
				{
					route.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
				}
			);

			//app.Run(async (context) =>
			//{
			//	await context.Response.WriteAsync("Hello World!");
			//});


		}
	}
}
