using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEC_EP1.Models
{
    public class TherapeuticClass
    {
        public TherapeuticClass()
        {
            this.Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}