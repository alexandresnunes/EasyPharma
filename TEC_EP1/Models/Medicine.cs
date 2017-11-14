using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEC_EP1.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string EAN { get; set; }
        public string Registration{ get; set; }
        public string Description { get; set; }
        public string Composition { get; set; }
        public int IdLab { get; set; }
        public int IdTherapeuticClass { get; set; }
        public int IdTaxByState { get; set; }
    }
}