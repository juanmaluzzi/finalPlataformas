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

        public DbSet<plataformasGrupo5TPFinal.Models.Alojamiento> Alojamiento { get; set; }

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

            //ALOJAMIENTOS
            modelBuilder.Entity<Alojamiento>()
              .ToTable("Alojamiento")
              .HasKey(a => a.id);

            modelBuilder.Entity<Alojamiento>(
                aloj =>
                {
                    aloj.Property(a => a.aCodigo).HasColumnType("int");
                    aloj.Property(a => a.aCodigo).IsRequired(true);
                    aloj.Property(a => a.aCiudad).HasColumnType("varchar(100)");
                    aloj.Property(a => a.aCiudad).IsRequired(true);
                    aloj.Property(a => a.aBarrio).HasColumnType("varchar(100)");
                    aloj.Property(a => a.aBarrio).IsRequired(true);
                    aloj.Property(a => a.aEstrellas).HasColumnType("int");
                    aloj.Property(a => a.aEstrellas).IsRequired(true);
                    aloj.Property(a => a.aCantPersonas).HasColumnType("int");
                    aloj.Property(a => a.aCantPersonas).IsRequired(true);
                    aloj.Property(a => a.aTV).HasColumnType("bit");
                    aloj.Property(a => a.Tipo).HasColumnType("varchar(20)");
                    aloj.Property(a => a.Tipo).IsRequired(true);
                    aloj.Property(a => a.cPrecioxDia).HasColumnType("float");
                    aloj.Property(a => a.cHabitaciones).HasColumnType("int");
                    aloj.Property(a => a.cbanios).HasColumnType("int");
                    aloj.Property(a => a.hPrecioxPersona).HasColumnType("float");
                }
            );

        }
    }
}
