using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Pruebas.Modelos;
using Xunit;

namespace XUnit.Pruebas
{
    
    public class AutorControllerTest
    {
        public AutorControllerTest()
        {
            Servicios.Inicializa();
        }

        [Fact]
        public async Task Autores_ObtenerTodosAsync_Total1()
        {
            
            var contenido = await Servicios.GetAsync("Autores");
            List<Autor> autores = JsonSerializer.Deserialize<List<Autor>>(contenido);
            Assert.Equal(1, autores.Count);
        }
    }
}
