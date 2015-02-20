using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpikiaTest.Model
{
    public class Account
    {
        [Key, ForeignKey("Transporter")]
        public Guid TransporterId { get; set; }
        public decimal Credits { get; set; }

        public virtual Transporter Transporter { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
