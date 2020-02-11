using Microsoft.EntityFrameworkCore;
using PrimerParcialAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcialAplicada.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Productos> productoTB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = ProductosDB2; Trusted_Connection = true;");
        }
    }
}
