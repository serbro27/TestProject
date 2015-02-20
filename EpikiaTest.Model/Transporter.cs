using System.Collections.Generic;

namespace EpikiaTest.Model
{
    public class Transporter : Actor
    {
        public virtual Account Account { get; set; }
        public virtual ICollection<Reuse> Reuses { get; set; }
    }
}
