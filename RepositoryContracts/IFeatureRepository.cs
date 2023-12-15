using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public  interface IFeatureRepository
    {


        /// <summary>
        /// Add a feature to the repository
        /// </summary>
        /// <param name="feature"></param>
        /// <returns>
        /// the added feature item</returns>
        Task<FeatureClass> AddFeature(FeatureClass feature);

        /// <summary>
        /// Delete a feature based from the repository based on the featureid
        /// </summary>
        /// <param name="FeatureId"></param>
        /// <returns>A boolean indicating whether deletion was successful</returns>



        Task<bool> DeleteFeatureByFeatureId(int FeatureId);


        /// <summary>
        /// Returns a list of feature from the repository
        /// </summary>
        /// <returns> a list of features</returns>
        Task<List<FeatureClass>> GetAllFeatures();

        public Task UpdateFeatureAsync(int featureId,FeatureUpdateRequest featureUpdateRequest);




        /// <summary>
        /// Updates an features in the repository.
        /// </summary>
        /// <param name="orderItem">The updated order item.</param>
        /// <returns>The updated feature</returns>
        //Task<FeatureClass> UpdateFeature(FeatureClass feature);
        /// <summary>
        /// Retrieve all the features of given specific entity
        /// </summary>
        /// <param name="EntityName"></param>
        /// <returns> list of features</returns>
        Task<List<FeatureClass>> GetFeaturesByEntityName(string EntityName);

         
        /// <summary>
        /// Retrieve feature by feature name
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns>a feature by given id</returns>
        Task<FeatureClass> GetFeatureByFeatureId(int featureId);
        /// <summary>
        /// Retrives Features by Feature Id
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns>Feature with matched feature featureid</returns>
        Task<List<FeatureClass>>GetFeaturesByUserName(string UserName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FeatureName"></param>
        /// <returns></returns>

        Task<FeatureClass> GetFeaturesByFeatureName(string FeatureName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        Task<FeatureClass> UpdateFeature(FeatureClass feature);
    }


















}





