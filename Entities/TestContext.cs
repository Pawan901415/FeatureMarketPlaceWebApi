using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class TestContext:DbContext
    {

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }


        public DbSet<EntityClass> Entities { get; set; }
        public DbSet<FeatureClass> Features { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EntityClass>().HasData(
                new EntityClass { EntityName = "Driver", Description = "This driver entity contains features for driver data" },
                new EntityClass { EntityName = "Character", Description = "This character entity contains features for Character data " },
                new EntityClass { EntityName = "Stock", Description = "This Stock entity contains features for Stock data" });

            modelBuilder.Entity<FeatureClass>().HasData(
                new FeatureClass { EntityName = "Driver", FeatureID = 1, FeatureName = "Rating", Value = "4.8", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now },
                new FeatureClass { EntityName = "Driver", FeatureID = 2, FeatureName = "TripsToday", Value = "12", FeatureDataType = "int", AdminComments = "good", CreatedAt = DateTime.Now },
                new FeatureClass { EntityName = "Character", FeatureID = 3, FeatureName = "Height", Value = "5.2", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now },
                new FeatureClass { EntityName = "Character", FeatureID = 4, FeatureName = "Width", Value = "12.6", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now },
                new FeatureClass { EntityName = "Stock", FeatureID = 5, FeatureName = "Price", Value = "2444.12", FeatureDataType = "double", AdminComments = "good", CreatedAt = DateTime.Now }
                );


            
        }




    }
}
