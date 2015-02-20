using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpikiaTest.Model
{
    public class Transaction : Entity
    {
        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public virtual Account Account { get; set; }
    }
}
