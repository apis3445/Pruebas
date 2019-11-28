using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pruebas.Datos;
using Pruebas.Modelos;

namespace XUnit.Pruebas
{
public class ContextoMemoria
{
    public CursosContext ObtenerContexto()
    {
        //Indicamos que utilizará base de datos en memoria
        //y que no deseamos que marque error si realizamos
        //transacciones en el código de nuestra aplicación
        var options = new DbContextOptionsBuilder<CursosContext>()
                        .ConfigureWarnings
                        (x => x.Ignore(InMemoryEventId
                                .TransactionIgnoredWarning))
                        .UseInMemoryDatabase(databaseName: "Test")
                                .Options;
        //Inicializamos la configuración de la base de datos
        var context = new CursosContext(options);
        //Mandamos llamar la función para inicializar los 
        //datos de prueba
        InicializaDatos.Inicializar(context);
        return context;
    }
}
}
