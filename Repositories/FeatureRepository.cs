using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initialize a new instance of the <see cref="FeatureRepository"/> class
        /// </summary>
        /// <param name="context"> the database context</param>
        public FeatureRepository(ApplicationDbContext context) {
        
        _context = context;
        
        }
        public  async Task<FeatureClass> AddFeature(FeatureClass feature)
        {

           








            _context.Features.Add(feature);
            await _context.SaveChangesAsync();  

            return feature;
        }

        public async Task<bool> DeleteFeatureByFeatureId(int FeatureId)
        {
            // find the feature with the specified id

            var feature=await _context.Features.FindAsync(FeatureId);

            if (feature == null)
            {
                return false;
            }
            // remove the feature from the database context
            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<FeatureClass>> GetAllFeatures()
        {
            var features = await _context.Features.ToListAsync();
            foreach (var feature in features)
            {
                if (feature.AdminComments == null && feature.UserName==null)
                {
                    feature.AdminComments = "No comments from admin";
                    feature.UserName = "Kunal";
                    _context.SaveChanges();
                    
                    // default value
                }
            }
            return features;
        }


        public async Task<FeatureClass> GetFeatureByFeatureId(int featureId)
        {
          var featureItem=await _context.Features.FindAsync(featureId);
           if (featureItem == null)
            {

                return null;
            }
           return featureItem;
        }

        public async Task<List<FeatureClass>> GetFeaturesByEntityName(string EntityName)
        {
            var featureItems = await _context.Features
            .Where(temp => temp.EntityName.ToLower() == EntityName.ToLower())
            .ToListAsync();
            return featureItems;

            return featureItems;
        }

        public async Task<List<FeatureClass>>GetFeaturesByUserName(string UserName)
        {
            var featureItems = await _context.Features
           .Where(temp => temp.UserName.ToLower() == UserName.ToLower())
           .ToListAsync();
            return featureItems;



        }



        public async Task<FeatureClass> GetFeaturesByFeatureName(string FeatureName)
        {
            var featureItem = await _context.Features
                .Where(f => f.FeatureName.Contains(FeatureName))
                .FirstOrDefaultAsync();
            if(featureItem == null)
            {
                return null;
            }

            return featureItem;
        }


       
    }
}
