using System;
using Pruebas;
using Xunit;

namespace XUnit.Pruebas
{
    public class WeatherForecastTests
    {
        [Fact]
        public void TemperatureF_SiTemperatureC100_ShouldBe211()
        {
        
            //Inicializar datos
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.TemperatureC = 100;
            //Ejecutar método
            var gradosFahrenheit = weatherForecast.TemperatureF;
            //Comprobar resultado
            Assert.Equal(211, gradosFahrenheit);
        }
    }
}
