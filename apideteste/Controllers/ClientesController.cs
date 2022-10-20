using apideteste.Migrations;
using apideteste.models;
using apideteste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apideteste.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private DbContexto db;
        public ClientesController(DbContexto _db)
        {
            this.db = _db;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public ActionResult Get()
        {
            
            
            return StatusCode(200, db.Clientes.ToList());
        }



        // POST api/<ClientesController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();
            return StatusCode(201, cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        { var clienteDb = db.Clientes.Find(id);
            if(id < 1 || clienteDb == null)
            {
                return StatusCode(404);
            }
            clienteDb.Nome = cliente.Nome;
            clienteDb.Telefone = cliente.Telefone;
            db.Clientes.Update(clienteDb);
            db.SaveChanges();

            return StatusCode(200, clienteDb);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var clienteDb = db.Clientes.Find(id);
            if (id < 1 || clienteDb == null)
            {
                return StatusCode(404);
            }
    
            db.Clientes.Remove(clienteDb);
            db.SaveChanges();

            return StatusCode(204);
        }
    }
}
