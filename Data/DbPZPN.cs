using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Data
{
    public class DbPZPN:DbContext
    {
        public DbSet<Zawodnik> Zawodnicy { get; set; }

        
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            string jsonString = File.ReadAllText("appsettings.json");
            JsonNode konfiguracja = JsonNode.Parse(jsonString); 
            string connectionString = (string)konfiguracja["ConnectionString"]["Baza"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

/*
Zeby utworzyć migracje, należy otworzyć narzedzia/Menadżer pakietów nuget/konsola menadżera a potem:
 Add-Migration dodanieZawodnikow
  -> enter
update-database
  -> enter
 */

