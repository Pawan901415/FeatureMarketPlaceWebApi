using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Entities
{
    public class ApplicationDbContext : DbContext   
    {

        /// <summary>
        /// Initializes a new instane of application DBContext 
        /// </summary>
        /// <param name="options"> The options for configuring the context </param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EntityClass>().HasData(
                new EntityClass { EntityName = "Driver", Description = "This driver entity contains features for driver data" },
                new EntityClass { EntityName = "Character", Description = "This character entity contains features for Character data " },
                new EntityClass { EntityName = "Stock", Description = "This Stock entity contains features for Stock data" });

            modelBuilder.Entity<FeatureClass>().HasData(
                new FeatureClass { EntityName = "Driver", FeatureID = 1, FeatureName = "Rating", Value = "4.8", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now,UserName="pawan" },
                new FeatureClass { EntityName = "Driver", FeatureID = 2, FeatureName = "TripsToday", Value = "12", FeatureDataType = "int", AdminComments = "good", CreatedAt = DateTime.Now ,UserName="kunal"},
                new FeatureClass { EntityName = "Character", FeatureID = 3, FeatureName = "Height", Value = "5.2", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now ,UserName= "kunal" },
                new FeatureClass { EntityName = "Character", FeatureID = 4, FeatureName = "Width", Value = "12.6", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now,UserName="kunal" },
                new FeatureClass { EntityName = "Stock", FeatureID = 5, FeatureName = "Price", Value = "2444.12", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now , UserName = "kunal" }
                );


            modelBuilder.Entity<EntityClass>().ToTable("EntityTbl");

            modelBuilder.Entity<FeatureClass>().ToTable("Features");
        }

        public DbSet<EntityClass> Entities { get; set; }
        public DbSet<FeatureClass> Features { get; set; }
    }
}
