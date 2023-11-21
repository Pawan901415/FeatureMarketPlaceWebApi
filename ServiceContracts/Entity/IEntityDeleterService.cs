using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Entity
{
    /// <summary>
    /// Represent a service for deleting entities
    /// </summary>
   public interface IEntityDeleterService
    {

        /// <summary>
        /// Delete and entity by entityname
        /// </summary>
        /// <param name="EntityName"> The name of the entity to be deleted </param>
        /// <returns> A boolean indiacting whether deletion was sucessful </returns>
        Task <bool>DeleteEntityByEntityName(string EntityName);
    }
}
