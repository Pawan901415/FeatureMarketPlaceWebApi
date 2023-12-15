using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts.Feature;



namespace FeatureMarketPlaceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureAdderService _featureAdderService;
        private readonly IFeatureDeleterService _featureDeleterService;
        private readonly IFeatureGetterService _featureGetterService;
        private readonly IFeatureUpdaterService _featureUpdaterService;

        // Injecting Services 

        public FeatureController(



        IFeatureUpdaterService featureUpdaterService,
        IFeatureDeleterService featureDeleterService,
        IFeatureGetterService featureGetterService,
       IFeatureAdderService featureAdderService


         )


        {

            _featureUpdaterService = featureUpdaterService;
            _featureDeleterService = featureDeleterService;
            _featureAdderService = featureAdderService;
            _featureGetterService = featureGetterService;
        }


        /// <summary>
        /// Retrieve all features based on specific entity
        /// </summary>
        /// <param name="entityName">the entityname</param>
        /// <returns>
        /// a list of features</returns>





        [HttpGet]
        [Route("GetFeaturesByEntityName/{EntityName}")]



        public async Task<ActionResult<List<FeatureResponse>>> GetFeaturesByEntityName(string EntityName)
        {
            var features = await _featureGetterService.GetFeatureByEntityName(EntityName);

            return Ok(features);
        }






        [HttpGet]
        [Route("GetFeaturesByUserName/{UserName}")]
        public async Task<ActionResult<List<FeatureResponse>>> GetFeaturesByUserName(string UserName)
        {
            var features = await _featureGetterService.GetFeaturesByUserName(UserName);
            return Ok(features.ToList());

        }


        [HttpGet]
        [Route("GetAllFeatures")]

        public async Task<ActionResult<List<FeatureResponse>>> GetAllFeatures()
        {

            var features = await _featureGetterService.GetAllFeature();

            return Ok(features);
        }



        [HttpGet]
        [Route("GetFilteredPersons/{SearchBy}/{SearchString}")]

        public async Task<ActionResult<List<FeatureResponse>>> GetFilteredFeatures(string SearchBy, string SearchString)
        {
            var featureItems = await _featureGetterService.GetFilteredFeature(SearchBy, SearchString);
            return Ok(featureItems);
        }





        /// <summary>
        /// Retrieve the feature by its id 
        /// </summary>
        /// <param name="FeatureId"></param>
        /// <returns>
        /// the retrieved feature or 404 not found 

        /// </returns>
        /// 
        [HttpGet]
        [Route("GetFeatureByFeatureId/{FeatureId:int}")]

        public async Task<ActionResult<FeatureResponse?>> GetFeatureById(int FeatureId)
        {

            var feature = await _featureGetterService.GetFeatureByFeatureId(FeatureId);

            return Ok(feature);

        }


        [HttpGet]
        [Route("GetFeatureByFeatureName/{FeatureName}")]

        public async Task<ActionResult<FeatureResponse?>> GetFeatureByFeatureName(string FeatureName)
        {

            var feature = await _featureGetterService.GetFeatureByFeatureName(FeatureName);

            return Ok(feature);

        }



        /// <summary>
        /// Adds a new feature
        /// </summary>
        /// <param name="EntityName">
        /// the entity  name of the feature</param>
        /// <param name="featureAddRequest"> the request containing the feature data</param>
        /// <returns></returns>

        [HttpPost]

        [Route("AddFeature")]



        public async Task<ActionResult<FeatureResponse>> AddFeature(FeatureAddRequest featureAddRequest)
        {
            var addedfeature = await _featureAdderService.AddFeature(featureAddRequest);

            return CreatedAtAction(nameof(AddFeature), addedfeature);
        }
        

        [HttpPost]
        [Route("AddMultipleFeatures")]
        public async Task<IActionResult> AddFeatures([FromBody] List<FeatureAddRequest> featureRequests)
        {
            try
            {
                var featureResponses = await _featureAdderService.AddMultipleFeatures(featureRequests);
                return Ok(featureResponses);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "Internal server error");
            }
        }




        /// <summary>
        /// Updates an existing feature.
        /// </summary>
        /// <param name="EntityName">The Name  of the feature</param>
        /// <param name="featureRequest">The request containing the updated feature data.</param>
        /// <returns>The updated feature item, or 400 Bad Request if the ID doesn't match the request.</returns>
        /// 
        [HttpPut]
        [Route("UpdateFeature/{id}")]

        
        public async Task<IActionResult> UpdateFeature(int id, [FromBody] FeatureUpdateRequest featureRequest)
        {
            try
            {
                var updatedFeature = await _featureUpdaterService.UpdateFeature(id, featureRequest);
                return Ok(updatedFeature);
            }
            catch (Exception ex)
            {
                // Logging the exception...
                return StatusCode(500, "Internal server error");
            }
        }






        /// <summary>
        /// Deletes an order item.
        /// </summary>

        /// <param name="FeatureId">The ID of the feature  to delete.</param>
        /// <returns>204 No Content if the deletion was successful, or 404 Not Found if the order item or order was not found.</returns>
        [HttpDelete]
        [Route("DeleteFeature/{FeatureId:int}")]
        
        
        public async Task<ActionResult> DeleteFeature( int FeatureId)
        {
           var isDeleted=await _featureDeleterService.DeleteFeatureByFeatureId(FeatureId).ConfigureAwait(false);

            if (!isDeleted)
            {
                return NotFound();
            }
            
            return NoContent();
        }










    }
}
