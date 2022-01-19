using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Village_project_teast_19._1._21.Models
{
    public partial class VillageDB : DbContext
    {
        public VillageDB()
            : base("name=VillageDB")
        {
        }

        public virtual DbSet<Citizen> Citizens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
