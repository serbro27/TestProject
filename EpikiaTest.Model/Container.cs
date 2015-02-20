using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpikiaTest.Model
{
    public class Container : Entity
    {
        [ForeignKey("Carrier")]
        public Guid CarrierId { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }

        public virtual Carrier Carrier { get; set; }
        public virtual ICollection<Reuse> Reuses { get; set; }
    }
}
