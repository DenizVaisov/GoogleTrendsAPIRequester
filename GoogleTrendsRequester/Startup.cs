using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GoogleTrendsRequester
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddLogging();
            
            services.AddNodeServices(options =>
            {
                options.LaunchWithDebugging = true;
                options.DebuggingPort = 9229;
            });
			
			services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins(
							"https://localhost:5001",
							"http://192.168.*:8080"
						)
                        .AllowAnyOrigin() 
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
			
			app.UseCors("AllowOrigin");
			app.UseAuthentication();
            app.UseHttpsRedirection();		
            app.UseMvc();
        }
    }
}