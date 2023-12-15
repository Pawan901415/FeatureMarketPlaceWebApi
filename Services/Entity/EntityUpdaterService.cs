using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entity
{

    
    public class EntityUpdaterService : IEntityUpdaterService
    {

        private readonly IEntityRepository _entityRepository;

        public EntityUpdaterService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<EntityResponse> UpdateEntity(string entityName, EntityUpdateRequest updateRequest)
        {
            // Pass the updateRequest directly to the repository method
            var updatedEntity = await _entityRepository.UpdateEntityAsync(entityName, updateRequest);

            var updatedEntityResponse = updatedEntity.ToEntityResponse();
            return updatedEntityResponse;
        }

       
    }
}
