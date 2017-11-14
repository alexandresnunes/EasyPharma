using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TEC_EP1.Models
{
    public class PBMProgram
    {
        public PBMProgram()
        {
            this.PBMProgramMedicines = new HashSet<PBMProgramMedicine>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdPBM { get; set; }

        public virtual ICollection<PBMProgramMedicine> PBMProgramMedicines { get; set; }
        //teste
        [ForeignKey("IdPBM")]
        public virtual PBM PBMs { get; set; }
    }
}