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
         }
    }

