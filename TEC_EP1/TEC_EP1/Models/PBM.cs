using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEC_EP1.Models
{
    public class PBM
    {
        public PBM()
        {
            this.PBMPrograms = new HashSet<PBMProgram>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PBMProgram> PBMPrograms { get; set; }
    }
}