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
        private readonly TestContext _context;
        /// <summary>
        /// Initialize a new instance of the <see cref="FeatureRepository"/> class
        /// </summary>
        /// <param name="context"> the database context</param>
        public FeatureRepository(TestContext context) {
        
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
            var featureitems=await _context.Features.OrderBy(temp=>temp.FeatureID).ToListAsync();
            return featureitems;
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
            var featureItems = await _context.Features.Where(temp => string.Equals(temp.EntityName,EntityName,StringComparison.OrdinalIgnoreCase)).ToListAsync();

            return featureItems;
        }

        public async  Task<FeatureClass> UpdateFeature(FeatureClass feature)
        {
           var existingFeatureItem=await _context.Features.FindAsync(feature.FeatureID);

            if(existingFeatureItem == null)
            {

                throw new ArgumentException($"Feature Item with ID {feature.FeatureID} doesn't exist");
            }

            // Update the properties of the existing Feature with the new value


            existingFeatureItem.FeatureID=feature.FeatureID;
            existingFeatureItem.FeatureName=feature.FeatureName;
            existingFeatureItem.AdminComments=feature.AdminComments;

            existingFeatureItem.ApprovalStatus=feature.ApprovalStatus;
            existingFeatureItem.CreatedAt=feature.CreatedAt;

            existingFeatureItem.FeatureDataType=feature.FeatureDataType;
            existingFeatureItem.UserID=feature.UserID;

            await _context.SaveChangesAsync();
            return existingFeatureItem;


        }
    }
}
