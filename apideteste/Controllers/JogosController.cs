using apideteste.models;
using apideteste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
                command.CommandText = "Select j.id as id, sa.nome as selecaoa, sb.nome as seleceaob," + 
                                        "j.golselecaoa as golsa, j.golselecaob as golsb, f.nome as fase," +
                                        "j.iniciojogo as iniciojogo, j.fimjogo as fimdejogo, j.tempoatual as tempoatual" +
                                        " from jogos as j" +
                                        " inner join selecao as sa on sa.id = j.selecaoaid" +
                                        " inner join selecao as sb on sb.id = j.selecaobid" + 
                                        " inner join fasecopa as f on f.id = j.fasecopaid";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        lista.Add(new
                        {
                            Id = Convert.ToInt32(result["id"]),
                            SelecaoA = result["selecaoa"],
                            SelecaoB = result["selecaob"],
                            GolA = Convert.ToInt32(result["golselecaoa"]),
                            GolB = Convert.ToInt32(result["golselecaob"]),
                            Fase = result["fase"],
                            InicioJogo = Convert.ToDateTime(result["iniciojogo"]),
                            FimJogo = Convert.ToDateTime(result["fimjogo"]),
                            TempoAtual = Convert.ToDateTime(result["tempoatual"])

                        });
                    }
                    return lista;
                }
            }


       }
        [HttpPost]
        public ActionResult Post([FromBody] Jogo jogo)
        {
            db.Jogos.Add(jogo);
            db.SaveChanges();
            return StatusCode(201, jogo);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Jogo jogo)
        {
            var jogoDb = db.Jogos.Find(id);
            if (id < 1 || jogoDb == null)
            {
                return StatusCode(404);
            }
            jogoDb.SelecaoA = jogo.SelecaoA;
            jogoDb.SelecaoB = jogo.SelecaoB;
            jogoDb.GolsSelecaoA = jogo.GolsSelecaoA;
            jogoDb.GolsSelecaoB = jogo.GolsSelecaoB;
            jogoDb.FaseCopaId = jogo.FaseCopaId;
            jogoDb.InicioJogo = jogo.InicioJogo;
            jogoDb.FimJogo = jogo.FimJogo;
            jogoDb.TempoAtual = jogo.TempoAtual;

            db.Jogos.Update(jogoDb);
            db.SaveChanges();

            return StatusCode(200, jogoDb);
        }

        public ActionResult Delete(int id)
        {
            var jogoDb = db.Admins.Find(id);
            if (id < 1 || jogoDb == null)
            {
                return StatusCode(404);
            }

            db.Admins.Remove(jogoDb);
            db.SaveChanges();

            return StatusCode(204);
        }
    }

   
}

