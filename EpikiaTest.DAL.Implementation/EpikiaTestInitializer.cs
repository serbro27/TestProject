using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EpikiaTest.Model;

namespace EpikiaTest.DAL.Implementation
{
    public class EpikiaTestInitializer : DropCreateDatabaseIfModelChanges<EpikiaTestContext>
    {
        protected override void Seed(EpikiaTestContext context)
        {
            var actors = new List<Actor>
            {
                new Carrier { Id = Guid.NewGuid(), Name = "John", Active = true, DateOfRegistration = DateTime.Now.AddDays(-90) },
                new Transporter { Id = Guid.NewGuid(), Name = "Peter", Active = true, DateOfRegistration = DateTime.Now.AddDays(-50) }
            };
            actors.ForEach(a => context.Actors.Add(a));
            context.SaveChanges();

            var accounts = new List<Account>
            {
                new Account { Credits = 1000, Transporter = context.Actors.OfType<Transporter>().First() }
            };
            accounts.ForEach(a => context.Accounts.Add(a));
            context.SaveChanges();

            var containers = new List<Container>
            {
                new Container { Id = Guid.NewGuid(), Size = 100, Price = 25, Carrier = context.Actors.OfType<Carrier>().First() }
            };
            containers.ForEach(c => context.Containers.Add(c));
            context.SaveChanges();

            var reuses = new List<Reuse>
            {
                new Reuse { Id = Guid.NewGuid(), Transporter = context.Actors.OfType<Transporter>().First(), Container = context.Containers.First(), DateOfReuse = new DateTime(2015, 5, 5), Status = ReuseStatus.Pending },
                new Reuse { Id = Guid.NewGuid(), Transporter = context.Actors.OfType<Transporter>().First(), Container = context.Containers.First(), DateOfReuse = new DateTime(2015, 4, 4), Status = ReuseStatus.Approved }
            };
            reuses.ForEach(r => context.Reuses.Add(r));
            context.SaveChanges();
        }
    }
}
