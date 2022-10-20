using apicopa.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using apicopa.models;

namespace apicopa.Controllers
{
    [Route("api/fasecopa")]
    [ApiController]
    public class FaseCopaController : ControllerBase
    {
        private DbContexto db;
        public FaseCopaController(DbContexto _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var lista = new List<dynamic>();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select id as id, nome as nome " +
                                        " from fasecopa";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        lista.Add(new
                        {
                            Id = Convert.ToInt32(result["id"]),
                            Nome = result["nome"],

                        });
                    }
                    return StatusCode(200, lista);
                }
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] FaseCopa fase)
        {
            db.FaseCopa.Add(fase);
            db.SaveChanges();
            return StatusCode(201, fase);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] FaseCopa fase)
        {
            var faseDb = db.FaseCopa.Find(id);
            if (id < 1 || faseDb == null)
            {
                return StatusCode(404);
            }
            faseDb.Nome = fase.Nome;

            db.FaseCopa.Update(faseDb);
            db.SaveChanges();

            return StatusCode(200, faseDb);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var faseDb = db.FaseCopa.Find(id);
            if (id < 1 || faseDb == null)
            {
                return StatusCode(404);
            }

            db.FaseCopa.Remove(faseDb);
            db.SaveChanges();

            return StatusCode(204);
        }
    }
}
