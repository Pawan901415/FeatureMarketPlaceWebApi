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

        public  async Task<FeatureResponse> UpdateFeature(FeatureUpdateRequest updateRequest)
        {
            // convert the update request to an Feature Entity

            var feature=updateRequest.ToFeature();

            var updatedFeature = await _repository.UpdateFeature(feature);

            return updatedFeature.ToFeatureResponse();




        }
    }
}
