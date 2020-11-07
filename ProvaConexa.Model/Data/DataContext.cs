
using Microsoft.EntityFrameworkCore;
using ProvaConexa.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConexa.Repositorio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Temperatura> Temperatura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).IsRequired();
                entity.Property(c => c.Latitutde).IsRequired();
                entity.Property(c => c.Longitude).IsRequired();
                entity.Ignore(c => c.Temperatura);
                entity.HasMany<Temperatura>(c => c.Temperatura).WithOne().HasForeignKey(t => t.Cidade_Id);

            });

            modelBuilder.Entity<Temperatura>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.TemperaturaCidade).IsRequired();
                entity.Property(t => t.Data).IsRequired();
            });
        }
    }
}
