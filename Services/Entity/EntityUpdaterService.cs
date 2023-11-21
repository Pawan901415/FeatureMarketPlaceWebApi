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
            public async Task<EntityResponse> UpdateEntity(EntityUpdateRequest updateRequest)
        {
            var entity=updateRequest.ToEntity();

            var updatedEntity=await _entityRepository.UpdateEntity(entity);
            var updatedEntityResponse=updatedEntity.ToEntityResponse();
            return updatedEntityResponse;   
        }
    }
}
