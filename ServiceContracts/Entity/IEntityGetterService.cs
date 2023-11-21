using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Entity
{

    /// <summary>
    /// epresent  a service for retriving orders
    /// </summary>
    public  interface IEntityGetterService
    {
        /// <summary>
        /// Retrive all entities
        /// </summary>
        /// <returns>  A list of entities</returns>
        Task<List<EntityResponse>> GetAllEntities();


        /// <summary>
        /// Retrieve an entity by its name
        /// </summary>
        /// <param name="EntityName"> the name of the entity to be retrieved</param>
        /// <returns>
        /// 
        /// the retrieved entity or null if not found 
        /// </returns>
        Task<EntityResponse> GetEntityByEntityName(string EntityName);

    }
}
