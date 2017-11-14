using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TEC_EP1.Models
{
    public class PBMProgramMedicine
    {
        [Key]
        public int Id { get; set; }
        public double PercDescPF { get; set; }
        public double PercDescPMC { get; set; }
        public string ExtraInfo { get; set; }
        public int IdPBMProgram { get; set; }
        public int IdMedicine { get; set; }

        [ForeignKey("IdMedicine")]
        public virtual Medicine Medicines { get; set; }

        [ForeignKey("IdPBMProgram")]
        public virtual PBMProgram PBMPrograms { get; set; }
    }
}