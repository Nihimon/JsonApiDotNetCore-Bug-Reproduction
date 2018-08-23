using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Extensions;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyApi.Controllers;

namespace MyApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			// Added custom resource services
			services.AddScoped<IResourceService<MyInt, int>, MyIntsService>();
			services.AddScoped<IResourceService<MyString, string>, MyStringsService>();
			services.AddScoped<IResourceService<MyGuid, Guid>, MyGuidsService>();

			// Modified to use AddMvcCore() instead of AddMvc().
			var coreBuilder = services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			// Register model types for ContextGraph.
			services.AddJsonApi(
				x =>
				{
					x.BuildContextGraph(
						builder =>
						{
							builder.AddResource<MyInt, int>("my-ints");
							builder.AddResource<MyString, string>("my-strings");
							builder.AddResource<MyGuid, Guid>("my-guids");
						});
				}, coreBuilder);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseHttpsRedirection();
			app.UseJsonApi();
			//app.UseMvc();
		}
	}
}
