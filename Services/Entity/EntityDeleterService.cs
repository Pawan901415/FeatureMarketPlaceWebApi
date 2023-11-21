using RepositoryContracts;
using ServiceContracts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entity
{
    public class EntityDeleterService : IEntityDeleterService
    {

        private readonly IEntityRepository _entityRepository;

        public EntityDeleterService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<bool> DeleteEntityByEntityName(string EntityName)
        {
            // calling the repository method to delete the entity


            var isDeleted=await _entityRepository.DeleteEntityByEntityName(EntityName);

            return isDeleted;
        }
    }
}
