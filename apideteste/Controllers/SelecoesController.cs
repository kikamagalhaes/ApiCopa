using apicopa.models;
using apicopa.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace apicopa.Controllers
{

        [Route("/api/selecoes")]
        [ApiController]
        

    public class SelecoesController : ControllerBase
        {
            private DbContexto db;
            public SelecoesController(DbContexto _db)
            {
                this.db = _db;
            }
        [HttpGet]
        [Route("")]
        public ActionResult Get()
            {
                var lista = new List<dynamic>();
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "Select id as id, nome as nome,descricao as descricao, " +
                                            "bandeira as urlbandeira" +
                                            " from selecao";
                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            lista.Add(new
                            {
                                Id = Convert.ToInt32(result["id"]),
                                Nome = result["nome"],
                                Descricao = result["descricao"],
                                Bandeira = result["urlbandeira"]

                            });
                        }
                        return StatusCode(200,lista);
                    }
                }
            }

        [HttpPost]
        [Route("")]
        public ActionResult Post([FromBody] Selecao selecao)
        {
            db.Selecao.Add(selecao);
            db.SaveChanges();
            return StatusCode(201, selecao);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, [FromBody] Selecao selecao)
        {
            var selecaoDb = db.Selecao.Find(id);
            if (id < 1 || selecaoDb == null)
            {
                return StatusCode(404);
            }
            selecaoDb.Nome = selecao.Nome;
            selecaoDb.Descricao = selecao.Descricao;
            selecaoDb.Bandeira = selecao.Bandeira;

            db.Selecao.Update(selecaoDb);
            db.SaveChanges();

            return StatusCode(200, selecaoDb);
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var selecaoDb = db.Selecao.Find(id);
            if (id < 1 || selecaoDb == null)
            {
                return StatusCode(404);
            }

            db.Selecao.Remove(selecaoDb);
            db.SaveChanges();

            return StatusCode(204);
        }
    }
    }

