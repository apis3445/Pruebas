using System;
using Pruebas.Modelos;

namespace Pruebas.Datos
{
public class InicializaDatos
{
    public static void Inicializar(CursosContext contexto)
    {
        //Te aseguras que la base de datos haya sido creada
        contexto.Database.EnsureCreated();

        var autores = new Autor[]
        {
            /*01*/ new Autor { Clave = 1, Nombre = "Juan Perez"},
        };
        foreach (Autor registro in autores)
        {
            contexto.Autores.Add(registro);
        }
        contexto.SaveChanges();
    }
}
}
