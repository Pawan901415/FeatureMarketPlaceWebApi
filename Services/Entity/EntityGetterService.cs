using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.Entity;
using ServiceContracts.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entity
{
    public  class EntityGetterService:IEntityGetterService
    {


        private readonly IEntityRepository _entityRepository;
        private readonly IFeatureGetterService _featureGetterService;


        public EntityGetterService(IEntityRepository entityRepository, IFeatureGetterService featureGetterService)
        {
            _entityRepository = entityRepository;
            _featureGetterService = featureGetterService;
        }

        public async Task<List<EntityResponse>> GetAllEntities()
        {
            var entities = await _entityRepository.GetAllEntities();
            var entityResponses = entities.ToEntityResponseList();

            //    foreach(var entityResponse in entityResponses)
            //    {
            //        entityResponse.FeatureItems = await _featureGetterService.GetFeatureByEntityName(EntityResponse)
            //    }

            //    return entityResponses;
            //}
            return entityResponses;

        }

        public async  Task<EntityResponse> GetEntityByEntityName(string EntityName)
        {

            var entity=await _entityRepository.GetEntityByName(EntityName);
            var entityResponse=entity.ToEntityResponse();

            return entityResponse;
            
        }
    }
}
