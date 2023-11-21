using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceContracts.DTO;

namespace ServiceContracts.Entity
{
    /// <summary>
    /// Reperesent a service for ading orders
    /// </summary>
   public  interface IEntityAdderService
    {
        Task<EntityResponse> AddEntity(EntityAddRequest entityRequest);

    }
}
