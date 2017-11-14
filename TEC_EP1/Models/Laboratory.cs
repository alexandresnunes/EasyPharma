using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TEC_EP1.Models
{
    public class Laboratory
    {
        public Laboratory()
        {
            this.Medicines = new HashSet<Medicine>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string CNPJ { get; set; }

        

        public virtual ICollection<Medicine> Medicines{ get; set; }

    }
}