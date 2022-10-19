using apideteste.models;
using apideteste.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace apideteste.Controllers
{

        [Route("api/selecoes")]
        [ApiController]
        public class SelecoesController : ControllerBase
        {
            private DbContexto db;
            public SelecoesController(DbContexto _db)
            {
                this.db = _db;
            }
            [HttpGet]
            public List<dynamic> Get()
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
                        return lista;
                    }
                }
            }

        [HttpPost]
        public ActionResult Post([FromBody] Selecao selecao)
        {
            db.Selecaos.Add(selecao);
            db.SaveChanges();
            return StatusCode(201, selecao);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Selecao selecao)
        {
            var selecaoDb = db.Selecaos.Find(id);
            if (id < 1 || selecaoDb == null)
            {
                return StatusCode(404);
            }
            selecaoDb.Nome = selecao.Nome;
            selecaoDb.Descricao = selecao.Descricao;
            selecaoDb.UrlImagemBandeira = selecao.UrlImagemBandeira;

            db.Selecaos.Update(selecaoDb);
            db.SaveChanges();

            return StatusCode(200, selecaoDb);
        }

        public ActionResult Delete(int id)
        {
            var selecaoDb = db.Selecaos.Find(id);
            if (id < 1 || selecaoDb == null)
            {
                return StatusCode(404);
            }

            db.Selecaos.Remove(selecaoDb);
            db.SaveChanges();

            return StatusCode(204);
        }
    }
    }

