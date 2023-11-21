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
    public class FeatureAdderService : IFeatureAdderService
    {



        private readonly IFeatureRepository _featureRepository;




        public FeatureAdderService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task<FeatureResponse> AddFeature(FeatureAddRequest featureRequest)
        {
            

            // Convert the request DTO to an Feature entity
            var feature = featureRequest.ToFeature();

            

            // Add the feature to the repository
            var addedfeature = await _featureRepository.AddFeature(feature);

            

            // Convert the feature item to a response DTO
            return addedfeature.ToFeatureResponse();
        } 
    }
}
