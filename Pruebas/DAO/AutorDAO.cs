using System;
using System.Collections.Generic;
using System.Linq;
using Pruebas.Modelos;

namespace Pruebas.DAO
{
public class AutorDAO
{
    private readonly CursosContext contexto;

    public AutorDAO(CursosContext contexto)
    {
        this.contexto = contexto;
    }

    public IEnumerable<Autor> ObtenerTodos()
    {
        return contexto.Autores.ToList();
    }

    public Autor ObtenerPorId(int id)
    {
        return contexto.Autores.Find(id);
    }

    public bool EsClaveRepetida(int id, int clave)
    {
        var registroRepetido = contexto.Autores
                                    .FirstOrDefault(c => c.Clave == clave
                                                        && c.Id != id);
        return registroRepetido != null;
    }
}
}
