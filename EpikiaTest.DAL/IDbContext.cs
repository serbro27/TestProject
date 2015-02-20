using System;
using System.Data.Entity;
using EpikiaTest.Model;

namespace EpikiaTest.DAL
{
    public interface IDbContext : IDisposable
    {
        IDbSet<Account> Accounts { get; set; }
        IDbSet<Actor> Actors { get; set; }
        IDbSet<Container> Containers { get; set; }
        IDbSet<Reuse> Reuses { get; set; }
        IDbSet<Transaction> Transactions { get; set; }
        IDbSet<Transporter> Transporters { get; set; }
        int SaveChanges();
    }
}
