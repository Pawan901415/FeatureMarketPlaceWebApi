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

        public async Task<List<FeatureResponse>>GetFeaturesByUserName(string UserName)
        {
            var featureitems=await _repository.GetFeaturesByUserName(UserName);
            return featureitems.ToFeatureResponseList();
        }

     ///  <inheritdoc />
     
        public async Task<FeatureResponse> GetFeatureByFeatureId(int featureId)
        {
            var featureItem=await _repository.GetFeatureByFeatureId(featureId);

            return featureItem.ToFeatureResponse();
        }

        public async Task<FeatureResponse>GetFeatureByFeatureName(string FeatureName)
        {
            var featureitem=await _repository.GetFeaturesByFeatureName(FeatureName);
            return featureitem.ToFeatureResponse();
        }

        public async Task<List<FeatureResponse>> GetFilteredFeature(string SearchBy, string SearchString)
        {
            var allFeatures = await _repository.GetAllFeatures();
           var matchingFeatures= allFeatures;

            if (string.IsNullOrEmpty(SearchBy) || string.IsNullOrEmpty(SearchString))
                return matchingFeatures.ToFeatureResponseList();
        


            switch (SearchBy)
            {
                case nameof(FeatureResponse.FeatureName ) :
                    matchingFeatures = allFeatures.Where(temp =>
                    (!string.IsNullOrEmpty(temp.FeatureName) ?
                    temp.FeatureName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(FeatureResponse.EntityName):
                    matchingFeatures = allFeatures.Where(temp =>
                    (!string.IsNullOrEmpty(temp.EntityName) ?
                    temp.EntityName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;


                case nameof(FeatureResponse.CreatedAt):
                    matchingFeatures= allFeatures.Where(temp =>
                    (temp.CreatedAt != null) ?
                    temp.CreatedAt.ToString("dd MMMM yyyy").Contains(SearchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(FeatureResponse.FeatureDataType):
                    matchingFeatures = allFeatures.Where(temp =>
                    (!string.IsNullOrEmpty(temp.FeatureDataType) ?
                    temp.FeatureDataType.Contains(SearchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(FeatureResponse.FeatureId):
                    matchingFeatures = allFeatures.Where(temp =>
                    (!string.IsNullOrEmpty(temp.FeatureID.ToString()) ?
                    temp.FeatureID.ToString().Contains(SearchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;


                default: matchingFeatures = allFeatures; break;
            }
            return matchingFeatures.ToFeatureResponseList();
        }

        public Task<List<FeatureResponse>> GetEntityByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
    }

