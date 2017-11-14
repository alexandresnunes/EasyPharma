using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TEC_EP1.Models;

namespace TEC_EP1.DAL
{
    public class EasyPharmaDbContext : DbContext
    {
        public EasyPharmaDbContext():base("EasyPharmaConnection")
        {

        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<PBM> PBMs { get; set; }
        public DbSet<PBMProgram> PBMPrograms { get; set; }
        public DbSet<PBMProgramMedicine> PBMProgramMedicines { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TaxByState> TaxByStates { get; set; }
        public DbSet<TherapeuticClass> TherapeuticClasses { get; set; }
    }
}