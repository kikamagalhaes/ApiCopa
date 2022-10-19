using apideteste.models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace apideteste.Services
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }


        public DbContexto() { }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<FaseCopa> FaseCopa { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Selecao> Selecao { get; set; }

    }
}
