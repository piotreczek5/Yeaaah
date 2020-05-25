using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreImplementation.Database;
using CoreImplementation.Database.Implementation;
using CoreImplementation.Database.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MultiModuleWebApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            RegisterDataBase(services);
        }

        private void RegisterDataBase(IServiceCollection services)
        {
            var database = new StandardDatabase();

            var autoCollections = DetectAllCollections();
            
            foreach(var collection in autoCollections)
            {
                database.Register(collection);
            }

            services.AddSingleton<IDataBase>(database);
        }

        private IEnumerable<IDBEntityCollection<IDBEntity>> DetectAllCollections()
        {
            var dbEntityTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IDBEntity).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            
            var collections = new List<IDBEntityCollection<IDBEntity>>();
            var collectionType = typeof(StandardDBEntityCollection<>);

            foreach (Type t in dbEntityTypes)
            {
                collections.Add(collectionType.MakeGenericType(t) as IDBEntityCollection<IDBEntity>);
            }

            return collections;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
