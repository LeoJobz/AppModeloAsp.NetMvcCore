﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIOUI.Site.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static DevIOUI.Site.Data.PedidoRepository;

namespace DevIOUI.Site
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.AreaPageViewLocationFormats.Clear();

            //    options.AreaPageViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
            //    options.AreaPageViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
            //    options.AreaPageViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            //});


            services.AddDbContext<MeuDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(name: "MeuDbContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IPedidoRepository, PedidoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //        name: "default",
                //        template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //mapeamento especifico para áreas
                routes.MapAreaRoute(name: "AreaProdutos", areaName: "Produtos", template: "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "AreaVendas", areaName: "Vendas", template: "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

            });
        }
    }
}
