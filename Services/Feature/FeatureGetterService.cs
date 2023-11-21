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
    public class FeatureGetterService : IFeatureGetterService
    {

        private readonly IFeatureRepository _repository;

        public FeatureGetterService(IFeatureRepository repository)
        {
            _repository = repository;
        }
        /// <inheritdoc />
        public async  Task<List<FeatureResponse>> GetAllFeature()
        {
            var featureItems=await _repository.GetAllFeatures();
            return featureItems.ToFeatureResponseList();
        }
        //Retrieve features based associated with the specified EntityName
        public async Task<List<FeatureResponse>> GetFeatureByEntityName(string entityName)
        {
            var entityItems=await _repository.GetFeaturesByEntityName(entityName);
            return entityItems.ToFeatureResponseList();
        }

     ///  <inheritdoc />
     
        public async Task<FeatureResponse> GetFeatureByFeatureId(int featureId)
        {
            var featureItem=await _repository.GetFeatureByFeatureId(featureId);

            return featureItem.ToFeatureResponse();
        }
    }
}
