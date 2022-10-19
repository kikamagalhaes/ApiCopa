using apideteste.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using apideteste.models;

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

        [HttpPost]
        public ActionResult Post([FromBody] Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return StatusCode(201, admin);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Admin admin)
        {
            var adminDb = db.Admin.Find(id);
            if (id < 1 || adminDb == null)
            {
                return StatusCode(404);
            }
            adminDb.Nome = admin.Nome;
            adminDb.Email = admin.Email;
            adminDb.Senha = admin.Senha;
           
            db.Admin.Update(adminDb);
            db.SaveChanges();

            return StatusCode(200, adminDb);
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            var adminDb = db.Admin.Find(id);
            if (id < 1 || adminDb == null)
            {
                return StatusCode(404);
            }

            db.Admin.Remove(adminDb);
            db.SaveChanges();

            return StatusCode(204);
        }
    }
    }
