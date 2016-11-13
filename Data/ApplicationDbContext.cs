using Data.CustomConventions;
using Data.modelMap;
using Domain;
using Domain.entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(): base("DB", throwIfV1Schema: false)
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
        static ApplicationDbContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Appartement> Appartements { get; set; }

        public DbSet<CollocationGroup> CollocationGroups { get; set; }
        public DbSet<CollocationOffre> CollocationOffres { get; set; }
        public DbSet<DiscutionGroup> DiscutionGroups { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Add(new Datetime2Convention());
            modelBuilder.Configurations.Add(new discutionGrouMapd().ToTable("discution"));
            modelBuilder.Configurations.Add(new userMap().ToTable("user"));
            modelBuilder.Configurations.Add(new GroupColloMap().ToTable("GroupCollocation"));


        }
    }
}
