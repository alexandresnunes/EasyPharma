using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEC_EP1.Models
{
    public class State
    {
        public State()
        {
            this.TaxByStates = new HashSet<TaxByState>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaxByState> TaxByStates { get; set; }
    }
}