using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pruebas.Modelos;

namespace Pruebas
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();   
            switch (CurrentEnvironment.EnvironmentName)
            {
                case "UnitTesting":
                    //Conexión en Memoria
                    services.AddDbContext<CursosContext>(opt => opt.UseInMemoryDatabase("Caltic")
                                                                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
                    break;
                case "IntegrationTesting":
                    //Conexión SQLite en memoria
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();
                    services.AddDbContext<CursosContext>(opt => opt.UseSqlite(connection));
                    break;
                default:
                    //Conexión SQL Server
                    services.AddDbContext<CursosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLServerConnection")));
                    break;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
