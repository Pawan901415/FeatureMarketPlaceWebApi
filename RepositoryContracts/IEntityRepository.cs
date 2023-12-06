using Entities;

namespace RepositoryContracts
{
    
    /// <summary>
/// Represent the repository contract for  Entities
/// </summary>
    public interface IEntityRepository
    {
        /// <summary>
        /// Adds an entity to the repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> The Added order</returns>

        Task<EntityClass> AddEntity(EntityClass entity);




        /// <summary>
        /// Retrieve all entities  from the repository
        /// </summary>
        /// <returns> a list of entities  </returns>
        Task<List<EntityClass>> GetAllEntities();

        



        /// <summary>
        /// 
        /// </summary>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        Task<EntityClass> GetEntityByName(string EntityName);


        /// <summary>
        /// Deletes an order from the repository based on its order ID.
        /// </summary>
        /// <param name="orderId">The ID of the order to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteEntityByEntityName(string EntityName);



        /// <summary>
        /// Updates an order in the repository.
        /// </summary>
        /// <param name="order">The updated order.</param>
        /// <returns>The updated order.</returns>
        Task<EntityClass> UpdateEntity(EntityClass entity);






    }
}