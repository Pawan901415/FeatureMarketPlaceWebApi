using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Entity
{
    public  interface IEntityUpdaterService
    {


        Task<EntityResponse> UpdateEntity(EntityUpdateRequest updateRequest);
    }
}
