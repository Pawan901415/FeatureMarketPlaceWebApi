using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Feature
{
    /// <summary>
    ///  Represent Service contract for retrieving Features
    /// </summary>
    public interface IFeatureGetterService
    {
        /// <summary>
        /// Retrieve all Features
        /// </summary>
        /// <returns>
        /// A list of features
        /// </returns>
        Task<List<FeatureResponse>> GetAllFeature();

        /// <summary>
        /// Retrieve Feature Based on specific EntityName
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns>
        /// A list of feature associated with a specific EntityName
        /// 
        /// </returns>

        Task<List<FeatureResponse>> GetFeatureByEntityName(string entityName);


        /// <summary>
        /// retrieve an feature based on featureId
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns>
        /// 
        /// the Features matching the feature id , or null if not found </returns>


        Task<FeatureResponse> GetFeatureByFeatureId(int featureId);




    }
}
