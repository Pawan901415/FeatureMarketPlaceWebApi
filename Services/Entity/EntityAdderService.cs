using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Entity;

namespace Services.Entity
{

    public class EntityAdderService : IEntityAdderService
    {

        private readonly IEntityRepository _entityRepository;

        private readonly IFeatureRepository _featureRepository;


        public EntityAdderService(IEntityRepository entityrepository,IFeatureRepository featureRepository)
        {

            _entityRepository = entityrepository;
            _featureRepository = featureRepository;

        }
        public async  Task<EntityResponse> AddEntity(EntityAddRequest entityRequest)
        {
            // Create a new Entity 
            var entity = entityRequest.ToEntity();


            // add the entity to repository

            var addedEntity=await _entityRepository.AddEntity(entity);

            var addedEntityResponse = addedEntity.ToEntityResponse();

            // add the features to the the repository and associate them to the with the entity

            foreach (var item in entityRequest.FeatureItems)
            {


                var feature = item.ToFeature();
                feature.EntityName = addedEntity.EntityName;

                var addedFeature = await _featureRepository.AddFeature(feature);

                addedEntityResponse.FeatureItems.Add(addedFeature.ToFeatureResponse());
            }
            return addedEntityResponse;

        }
    }
}
