using System;
using System.ComponentModel.DataAnnotations;

namespace EpikiaTest.Model
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
