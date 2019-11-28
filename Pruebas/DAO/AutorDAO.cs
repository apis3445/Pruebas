using System;
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

    public bool EsClaveRepetida(int id, int clave)
    {
        var registroRepetido = contexto.Autores
                                    .FirstOrDefault(c => c.Clave == clave
                                                        && c.Id != id);
        return registroRepetido != null;
    }
}
}
