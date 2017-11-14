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
    }
}