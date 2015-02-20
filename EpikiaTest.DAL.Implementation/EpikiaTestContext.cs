using System;
using System.Data.Entity;
using System.Linq;
using EpikiaTest.Model;

namespace EpikiaTest.DAL.Implementation
{
    public class EpikiaTestContext : DbContext, IDbContext
    {
        public EpikiaTestContext()
            : base("EpikiaTestContext")
        {
        }

        static EpikiaTestContext()
        {
            Database.SetInitializer(new EpikiaTestInitializer());
        }

        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Actor> Actors { get; set; }
        public IDbSet<Container> Containers { get; set; }
        public IDbSet<Reuse> Reuses { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }
        public IDbSet<Transporter> Transporters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transporter>()
                .HasOptional(t => t.Account)
                .WithRequired(a => a.Transporter);

            modelBuilder.Entity<Reuse>()
                .HasRequired(r => r.Transporter)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        public override int SaveChanges()
        {
            var changedAccounts = ChangeTracker.Entries<Account>().Where(e => e.State == EntityState.Modified);
            foreach (var changedAccount in changedAccounts)
            {
                var creadits = changedAccount.Property(x => x.Credits);
                if (creadits.IsModified)
                {
                    var transaction = new Transaction
                    {
                        Id = Guid.NewGuid(),
                        Account = changedAccount.Entity,
                        Amount = creadits.CurrentValue - creadits.OriginalValue,
                        DateOfTransaction = DateTime.Now
                    };
                    Transactions.Add(transaction);
                }
            }

            return base.SaveChanges();
        }
    }
}
