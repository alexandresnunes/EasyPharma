using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TEC_EP1.Models
{
    public class TaxByState
    {
        public TaxByState()
        {
            this.Medicines = new HashSet<Medicine>();
        }

        [Key]
        public int Id { get; set; }
        public double PF { get; set; }
        public double PMC { get; set; }
        public int IdState { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }

        [ForeignKey("IdState")]
        public virtual State States { get; set; }
    }
}