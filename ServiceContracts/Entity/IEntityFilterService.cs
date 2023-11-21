using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Entity
{
    public interface IEntityFilterService
    {

        /// <summary>
        /// Retrieve filter based on serach criteria
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="searchstring"></param>
        /// <returns></returns>
        Task<List<EntityResponse>> GetFilterEntity(string searchBy, string searchstring);
    }
}
