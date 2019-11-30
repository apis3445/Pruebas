using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pruebas.DAO;
using Pruebas.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pruebas.Controllers
{
[Route("api/[controller]")]
public class AutoresController : Controller
{
    private AutorDAO autorDAO;

    public AutoresController(CursosContext contexto)
    {
        autorDAO = new AutorDAO(contexto);
    }

    [HttpGet]
    public IEnumerable<Autor> Get()
    {
        return autorDAO.ObtenerTodos();
    }

        
        [HttpGet("{id}")]
        public Autor Get(int id)
        {
            return autorDAO.ObtenerPorId(id);
        }

        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
