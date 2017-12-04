using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XiaoQingWa_Work_Web_Core
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
            string connStr = Configuration.GetSection("ConnStr").Value;

            ////注入
            //services.AddSingleton<XiaoQingWa_Work_DAL.UserInfoRepository>(new XiaoQingWa_Work_DAL.UserInfoRepository() { ConnStr = connStr });
            //services.AddSingleton<DAL.OutlayDAL>(new DAL.OutlayDAL() { ConnStr = connStr });
            //services.AddSingleton<DAL.CategoryDAL>(new DAL.CategoryDAL() { ConnStr = connStr });
            //services.AddSingleton<DAL.IncomeDAL>(new DAL.IncomeDAL() { ConnStr = connStr });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
