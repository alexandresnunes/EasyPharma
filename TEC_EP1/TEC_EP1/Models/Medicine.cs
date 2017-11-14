using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEC_EP1.Models
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }
        public string EAN { get; set; }
        public string Registration{ get; set; }
        public string Description { get; set; }
        public string Composition { get; set; }
        public int IdLab { get; set; }
        public int IdTherapeuticClass { get; set; }
        public int IdTaxByState { get; set; }

        [ForeignKey ("IdLab")]
        public virtual Laboratory  Laboratories{ get; set; }

        [ForeignKey("IdTherapeuticClass")]
        public virtual TherapeuticClass TherapeuticClasses { get; set; }

        [ForeignKey("IdTaxByState")]
        public virtual TaxByState TaxByStates { get; set; }

        public virtual ICollection<PBMProgramMedicine> PBMProgramMedicines { get; set; }
    }
}