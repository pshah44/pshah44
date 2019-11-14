using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskManager.Data;

namespace TaskManager
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
                                                                                        // return data in according to header request from client i.e. json/xml
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddXmlDataContractSerializerFormatters();
            // add dbcontext service to communicate to database
            services.AddDbContext<TasksDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("TaskDBContext")));
            services.AddSwaggerGen(c => c.SwaggerDoc("v1",new Info() { Title ="Task Manager",Version ="v1"}));
            //services.AddDbContext<TasksDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDb;"));
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, TasksDbContext tasksDbContext)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
            // user swagger to generate documentation
            app.UseSwagger();
            // user swagger Ui to generate documentation
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api for Tasks Manager"));
			app.UseMvc();
            // create database if does not exist.
            tasksDbContext.Database.EnsureCreated();

        }
	}
}
