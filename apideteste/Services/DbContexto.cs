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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<FaseCopa> FaseCopas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Selecao> Selecaos { get; set; }

    }
}
