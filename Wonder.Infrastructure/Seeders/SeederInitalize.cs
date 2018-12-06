using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using Wonder.Core.Models;
using Wonder.Infrastructure.EF;

namespace Wonder.Infrastructure.Seeders
{
    public class SeederInitalize : System.Data.Entity.DropCreateDatabaseAlways<WonderMoonContext>
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



            var users = Builder<User>.CreateListOfSize(100)
                .All()
                    .With(c => c.FirstName = Faker.Name.First())
                    .With(c => c.SecondName = Faker.Name.Last())
                    .With(c => c.EmailAddress = Faker.Internet.Email())
                    .With(c => c.PrimaryAddress = Faker.Address.StreetAddress())
                    .With(c => c.HomePhone = Faker.RandomNumber.Next(11111, 99999).ToString())
                    .With(c => c.MobilePhone = Faker.RandomNumber.Next(11111,99999).ToString())
                       .With(c => c.RolId = Faker.RandomNumber.Next(1, 4))
                .Build();

            foreach (var u in users)
            {
                context.Users.Add(u);

            }
            context.SaveChanges();
        }

    }
}
