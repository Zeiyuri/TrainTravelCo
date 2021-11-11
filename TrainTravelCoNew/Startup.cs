using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCoNew.Models;

namespace TrainTravelCoNew
{
    public class Startup
    {
        private string _filePath = @$"D:\Fullstack\TrainTravelCoNew\TrainTravelCoNew\DataStorage\";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string[] filesInDirectory = Directory.GetFiles(@$"{_filePath}trains");
            List<string> correctFiles = new();

            for (int i = 0; i < filesInDirectory.Length; i++)
            {
                filesInDirectory[i] = Path.GetFileName(filesInDirectory[i]);
                if (filesInDirectory[i].StartsWith("train_"))
                {
                    correctFiles.Add(filesInDirectory[i]);
                }
            }
            Train temp = new();
            if(correctFiles.Count == 0)
            {
                temp.SetIdCountAtStartup(0);
            }
            else if(correctFiles.Count >=1)
            {
                using (StreamReader sr = new($@"{_filePath}trains\{correctFiles[correctFiles.Count-1]}"))
                {
                    temp.SetIdCountAtStartup(int.Parse(sr.ReadLine())+1);
                }
            }
            
            
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainTravelCoNew", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainTravelCoNew v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
