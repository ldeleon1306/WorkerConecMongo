using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerConecMongo
{
    class Wap_IngresosPedidosContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Server=sql_server2022;Database=SalesDb;User Id=SA;Password=A&VeryComplex123Password;MultipleActiveResultSets=true"
            //optionsBuilder.UseSqlServer("Server=DBINTERFWHSDESA;Database=InterfacesWHS;User Id=User_InterfacesWHS;Password=0jIN7HD9BlT6cnGoKZYa;MultipleActiveResultSets=true;");
            //optionsBuilder.UseSqlServer("Data Source=DBINTERFWHSDESA;Initial Catalog=InterfacesWHS;User ID=User_InterfacesWHS;Password=0jIN7HD9BlT6cnGoKZYa;Integrated Security=False;");
            optionsBuilder.UseSqlServer(@"Data Source=DBINTERFWHSTEST;Initial catalog=InterfacesWHS;Integrated Security=true");
            //optionsBuilder.UseSqlServer(@"Data Source=SQLSCECYPESRV;Initial catalog=InterfacesWHS;Integrated Security=true");
            //optionsBuilder.UseSqlServer(@"Data Source=ITGDESAOCSRV;Initial catalog=AccionesBBVA;Integrated Security=true");
        }

        public DbSet<WAP_INGRESOPEDIDOS> WAP_INGRESOPEDIDOS { get; set; }
    }
}
