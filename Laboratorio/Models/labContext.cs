using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Laboratorio.Models
{
    public class labContext : DbContext
    {
        public labContext(DbContextOptions<labContext> options) : base(options) 
        {

        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Motoristas> Motoristas { get; set;}
        public DbSet<Pedidos> Pedidos { get; set;}
        public DbSet<Platos> Platos { get; set;}
    }
}
