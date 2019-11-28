using System;
using Pruebas.DAO;
using Pruebas.Modelos;
using Xunit;

namespace XUnit.Pruebas
{
    public class AutorTest
    {
        CursosContext contexto;
        public AutorTest()
        {          
            contexto = new ContextoMemoria().ObtenerContexto();
        }

        [Fact]
        public void AutorDAO_EsClaveRepetida_Clave1_EsTrue()
        {
            //Inicializar datos  
            AutorDAO autorDAO = new AutorDAO(contexto);
            //Ejecutar método
            var esRepetido = autorDAO.EsClaveRepetida(2,1);
            //Comprobar resultado
            Assert.True(esRepetido);
        }
    }
}
