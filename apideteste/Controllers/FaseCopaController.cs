using apideteste.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace apideteste.Controllers
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
        public List<dynamic> Get()
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
                    return lista;
                }
            }
        }
    }
}
