using RepositoryContracts;
using ServiceContracts.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Feature
{
    public class FeatureDeleterService : IFeatureDeleterService
    {

        private readonly IFeatureRepository _featureRepository;



        public FeatureDeleterService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task<bool> DeleteFeatureByFeatureId(int featureId)
        {   

            // delete the feature based on featureid
            var isDeleted=await _featureRepository.DeleteFeatureByFeatureId(featureId);
            
            
            
            return isDeleted;
        }
    }
}
