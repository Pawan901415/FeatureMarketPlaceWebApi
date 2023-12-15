using Entities;
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
        private IEntityRepository entityRepository;
        private IFeatureRepository featureRepository;
        private IEntityRepository @object;

       
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

        public async Task<List<string>> GetEntityNamesByUserName(string userName)
        {
            var entities=await _entityRepository.GetEntityNamesByUserName(userName);
            return(entities);
        }
    }
}
