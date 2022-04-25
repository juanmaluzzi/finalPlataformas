using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plataformasGrupo5TPFinal.Models;

namespace plataformasGrupo5TPFinal.Data
{
    public class UserContext : DbContext
    {
        public DbSet<plataformasGrupo5TPFinal.Models.Cabaña> Cabaña { get; set; }

        public DbSet<plataformasGrupo5TPFinal.Models.Hotel> Hotel { get; set; }

        public DbSet<plataformasGrupo5TPFinal.Models.Usuario> Usuario { get; set; }

        public DbSet<plataformasGrupo5TPFinal.Models.Reservas> Reservas { get; set; }

        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                //BACKUP-> @"Data Source = basedv.ddns.net\DVTN; Database=tp4_plataformas; User Id = paloma.menendez@davinci.edu.ar; Password=Dv2021"
                optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
            }
            catch (Exception e)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //USUARIOS
            modelBuilder.Entity<Usuario>().ToTable("Usuarios").HasKey(u => u.id);
            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.dni).HasColumnType("int").IsRequired(true);
                    usr.Property(u => u.mail).HasColumnType("nvarchar(100)");
                    usr.Property(u => u.nombre).HasColumnType("nvarchar(100)");
                    usr.Property(u => u.password).HasColumnType("nvarchar(100)");
                    usr.Property(u => u.esAdmin).HasColumnType("bit");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                    usr.Property(u => u.intentos).HasColumnType("int");
                });

            //RESERVAS
            modelBuilder.Entity<Reservas>().ToTable("reservas").HasKey(r => r.id);
            modelBuilder.Entity<Reservas>(
               res =>
               {
                   res.Property(r => r.id).HasColumnType("int").IsRequired(true);
                   res.Property(r => r.fDesde).HasColumnType("DateTime");
                   res.Property(r => r.fHasta).HasColumnType("DateTime");
                   res.Property(r => r.codAlojamiento).HasColumnType("int");
                   res.Property(r => r.dniPersona).HasColumnType("int");
                   res.Property(r => r.precio).HasColumnType("real");
               });

            //CABAÑAS
            modelBuilder.Entity<Cabaña>().ToTable("Cabañas").HasKey(c => c.idCabana);
            modelBuilder.Entity<Cabaña>(
                cab =>
                {
                    cab.Property(c => c.codigo).HasColumnType("int").IsRequired(true);
                    cab.Property(c => c.nombre).HasColumnType("nvarchar(100)");
                    cab.Property(c => c.ciudad).HasColumnType("nvarchar(100)");
                    cab.Property(c => c.barrio).HasColumnType("nvarchar(100)");
                    cab.Property(c => c.estrellas).HasColumnType("int");
                    cab.Property(c => c.cantPersonas).HasColumnType("int");
                    cab.Property(c => c.tv).HasColumnType("bit");
                    cab.Property(c => c.precioDia).HasColumnType("real");
                    cab.Property(c => c.habitaciones).HasColumnType("int");
                    cab.Property(c => c.baños).HasColumnType("int");
                });

            //HOTELES
            modelBuilder.Entity<Hotel>().ToTable("Hotel").HasKey(h => h.idHotel);
            modelBuilder.Entity<Hotel>(
               hot =>
               {
                   hot.Property(h => h.codigo).HasColumnType("int").IsRequired(true);
                   hot.Property(h => h.nombre).HasColumnType("nvarchar(100)");
                   hot.Property(h => h.ciudad).HasColumnType("nvarchar(100)");
                   hot.Property(h => h.barrio).HasColumnType("nvarchar(100)");
                   hot.Property(h => h.estrellas).HasColumnType("int");
                   hot.Property(h => h.cantPersonas).HasColumnType("int");
                   hot.Property(h => h.tv).HasColumnType("int");
                   hot.Property(h => h.precioPorPersona).HasColumnType("real");
               });

            modelBuilder.Ignore<Alojamiento>();
        }
    }
}
