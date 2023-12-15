using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Feature
{
    
    /// <summary>
/// Represent the service contract for adding new features
/// </summary>
    public interface IFeatureAdderService
    {
        /// <summary>
        /// add a new feature
        /// </summary>
        /// <param name="featureRequest"></param>
        /// <returns>
        /// 
        /// the added feature
        /// </returns>
        Task<FeatureResponse> AddFeature(FeatureAddRequest featureRequest);

        Task<List<FeatureResponse>> AddMultipleFeatures(List<FeatureAddRequest> featureRequests);

    }
}
