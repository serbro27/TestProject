using System.Collections.Generic;

namespace EpikiaTest.Model
{
    public class Carrier : Actor
    {
        public virtual ICollection<Container> Containers { get; set; }
    }
}
