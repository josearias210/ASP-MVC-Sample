using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using Wonder.Core.Models;
using Wonder.Infrastructure.EF;

namespace Wonder.Infrastructure.Seeders
{
    public class SeederInitalizeTest : System.Data.Entity.DropCreateDatabaseAlways<WonderMoonContext>
    {
        protected override void Seed(WonderMoonContext context)
        {
            var roles = new List<Rol> {
                new Rol{ RolId = 1, Name = "Administrador" },
                new Rol{ RolId=2,Name="Operador"},
                new Rol { RolId=3, Name = "Consultas" },
                new Rol { RolId =4, Name="WebService" }
        };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
        }

    }
}
