using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Pruebas;
using Pruebas.Datos;
using Pruebas.Modelos;

namespace XUnit.Pruebas
{
    public class Servicios
    {

        private static HttpClient httpCliente;
        public static CursosContext cursosContext;

        public static void Inicializa()
        {
            //Creamos un servidor de pruebas utilizando un ambiente
            //de testing
            var builder = new WebHostBuilder()
                    .UseEnvironment("IntegrationTesting")
                    .ConfigureAppConfiguration((c, config) =>
                    {
                        config.SetBasePath(Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "..", "..", "..", "..", "Pruebas"));

                        config.AddJsonFile("appsettings.json");
                    })
                    .UseStartup<Startup>();
            //Esto nos crea un servidor con los servicios rest 
            var servidorPruebas = new TestServer(builder);
            //Obtenemos el objeto caducaContext
            cursosContext = servidorPruebas.Host.Services.GetService(typeof(CursosContext)) as CursosContext;
            //Inicializamos la bd con datos de prueba
            InicializaDatos.Inicializar(cursosContext);
            //var total =caducaContext.Usuario.Count();
            httpCliente = servidorPruebas.CreateClient();
        }

        public static async Task<string> GetAsync(string servicio)
        {
            var httpResponse = await httpCliente.GetAsync("api/" + servicio);
            if (httpResponse.IsSuccessStatusCode)
                return await httpResponse.Content.ReadAsStringAsync();
            return null;
        }
    }

}