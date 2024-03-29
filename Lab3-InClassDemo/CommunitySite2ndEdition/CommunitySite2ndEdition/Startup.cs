﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CommunitySite2ndEdition
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)

        {

            /* Add this */
            //adds MVC framework
            services.AddMvc();

        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env)

        {

            if (env.IsDevelopment())

            {

                app.UseDeveloperExceptionPage();

            }



            /* Comment this out */

            //app.Run(async (context) => {

            // await context.Response.WriteAsync("Hello World!");

            //});



            /* Add this */

            app.UseMvcWithDefaultRoute();

        }

    }
}
