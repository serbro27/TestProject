using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpikiaTest.Model
{
    public class Reuse : Entity
    {
        [ForeignKey("Container")]
        public Guid ContainerId { get; set; }
        [ForeignKey("Transporter")]
        public Guid TransporterId { get; set; }
        public ReuseStatus Status { get; set; }
        public DateTime DateOfReuse { get; set; }
        public decimal Price { get; set; }

        public virtual Container Container { get; set; }
        public virtual Transporter Transporter { get; set; }
    }
}
