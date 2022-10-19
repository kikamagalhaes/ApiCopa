using apideteste.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace apideteste.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private DbContexto db;
        public AdminController(DbContexto _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public List<dynamic> Get()
        {
            var lista = new List<dynamic>();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select id as id, nome as nome, email as email, senha as senha " +
                                        " from admin";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        lista.Add(new
                        {
                            Id = Convert.ToInt32(result["id"]),
                            Nome = result["nome"],
                            Email = result["email"],
                            Senha = result["senha"]

                        });
                    }
                    return lista;
                }
            }
        }
      }
    }
