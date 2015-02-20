using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpikiaTest.Model
{
    public abstract class Actor : Entity
    {
        public bool Active { get; set; }
        public DateTime DateOfRegistration { get; set; }
        [Index("NameIndex", IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
