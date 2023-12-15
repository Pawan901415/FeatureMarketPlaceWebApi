using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeatureMarketPlaceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {


        private readonly IEntityAdderService _entityAdderService;
        private readonly IEntityDeleterService _entityDeleterService;
        private readonly IEntityUpdaterService _entityUpdaterService;
        private readonly IEntityGetterService _entityGetterService;

        public EntityController(

           IEntityAdderService entityAdderService,
           IEntityDeleterService entityDeleterService,
           IEntityUpdaterService entityUpdaterService,
           IEntityGetterService entityGetterService



           ) {

            _entityAdderService = entityAdderService;
            _entityDeleterService = entityDeleterService;
            _entityUpdaterService = entityUpdaterService;
            _entityGetterService = entityGetterService;


        }




        /// <summary>
        /// Retrieve all entities 
        /// </summary>
        /// <returns>
        /// a list of entities</returns>

        [HttpGet]
        [Route("GetAllEntities")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<EntityResponse>>> GetAllEntities()
        {
            var entities = await _entityGetterService.GetAllEntities();

            return Ok(entities);
        }


        [HttpGet]
        [Route("GetEntitiesByUserName/{UserName}")]
        public async Task<ActionResult<List<string>>>GetEntitiesByUserName(string UserName) {

            var entities = await _entityGetterService.GetEntityNamesByUserName(UserName);
            return Ok(entities);


            }



        /// <summary>
        /// Retrieve an entity by its entityname
        /// </summary>
        /// <param name="entityName"> the name of entity to be retrieved</param>
        /// <returns>
        /// the retrieved entity or NotFound if not found</returns>

        [HttpGet]
        [Route("GetEntityByEntityName/{EntityName}")]
      

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<EntityResponse>> GetEntityByEntityName(string EntityName)
        {

            var entity = await _entityGetterService.GetEntityByEntityName(EntityName);

            if (entity == null)
            {
                return NotFound();
            }
            var entityResponse = entity.ToEntityResponse();
            return Ok(entityResponse);
        }


        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entityAddRequest"> the entity details</param>
        /// <returns>
        /// the added entity
        /// </returns>

        [HttpPost]
        [Route("AddEntity")]
    
        [ProducesResponseType(StatusCodes.Status201Created)]
        
        public async Task<ActionResult<EntityResponse>> AddEntity(EntityAddRequest entityAddRequest)
        {
            var addedEntity = await _entityAdderService.AddEntity(entityAddRequest);

            return CreatedAtAction(nameof(GetEntityByEntityName), new { addedEntity.EntityName }, addedEntity);



        }







        /// <summary>
        /// Updates an existing Entity
        /// </summary>
        /// <param name="EntityName"> the name of the entity to be upadated </param>
        /// <param name="entityUpdateRequest"> the updated entity details</param>
        /// <returns> the updated entity</returns>
        /// 

        [HttpPut]
        [Route("UpdateEntity/{EntityName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EntityResponse>> UpdateEntity(string EntityName, EntityUpdateRequest entityUpdateRequest)
        {
            var updatedEntity = await _entityUpdaterService.UpdateEntity(EntityName, entityUpdateRequest);
            return Ok(updatedEntity);
        }






        /// <summary>
        /// Deletes an entity by its EntityName.
        /// </summary>
        /// <param name="EntityName">The EntityName of the entity to delete.</param>
        /// <returns>No content if deletion is successful, or NotFound if entity not found.</returns>\
        /// 
        [HttpDelete]
        [Route("DeleteEntity/{EntityName}")]
       
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEntity(string EntityName)
        {


            var isDeleted = await _entityDeleterService.DeleteEntityByEntityName(EntityName);

            if (!isDeleted)
            {
               
                return NotFound();
            }

          

            return NoContent();
        }




    }
}
