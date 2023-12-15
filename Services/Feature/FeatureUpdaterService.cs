using Repositories;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Feature
{
    /// <summary>
    /// Service class for updating feature item
    /// </summary>
    public class FeatureUpdaterService : IFeatureUpdaterService
    {


        private readonly IFeatureRepository _repository;

        public FeatureUpdaterService(IFeatureRepository repository)
        {
            _repository = repository;
        }

        public async  Task<FeatureResponse> UpdateFeature(int id, FeatureUpdateRequest featureRequest)
        {

            // Getting the existing feature from the repository
            var existingFeature = await _repository.GetFeatureByFeatureId(id);

            if (existingFeature == null)
            {
                throw new Exception("Feature not found");
            }

            // Update the fields of the existing feature
            if (featureRequest.FeatureName != null)
            {
                existingFeature.FeatureName = featureRequest.FeatureName;
            }
            if (featureRequest.Value != null)
            {
                existingFeature.Value = featureRequest.Value;
            }
            if (featureRequest.FeatureDataType != null)
            {
                existingFeature.FeatureDataType = featureRequest.FeatureDataType;
            }

            // Saving the updated feature back to the repository
            var updatedFeature = await _repository.UpdateFeature(existingFeature);

            // Converting the updated feature to a response DTO using the ToFeatureResponse extension method
            return updatedFeature.ToFeatureResponse();
        }







        
    }
}
