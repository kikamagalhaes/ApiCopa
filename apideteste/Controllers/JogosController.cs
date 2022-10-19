using apideteste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apideteste.Controllers
{
    [Route("api/jogos")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private DbContexto db;
        public JogosController(DbContexto _db)
        {
            this.db = _db;
        }
        // GET api/<JogosController>/5
        [HttpGet]
        public List<dynamic> Get()
        {
            var lista = new List<dynamic>();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select id from jogos";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        lista.Add(new
                        {
                            Id = Convert.ToInt32(result["Id"]),

                        });
                    }
                    return lista;
                }
            }


       }
     }
 }

