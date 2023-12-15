using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
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
        private ApplicationDbContext dbContext;

       

        public EntityAdderService(IEntityRepository entityrepository,IFeatureRepository featureRepository)
        {

            _entityRepository = entityrepository;
            _featureRepository = featureRepository;

        }
        public async Task<EntityResponse> AddEntity(EntityAddRequest entityRequest)
        {
            if (entityRequest != null)
            {
                // Create a new Entity 
                var entity = entityRequest.ToEntity();

                // Check if the entity already exists in the repository
                var existingEntity = await _entityRepository.GetEntityByName(entity.EntityName);
                if (existingEntity != null)
                {
                    throw new ArgumentException($"An entity with the name {entity.EntityName} already exists.");
                }

                // add the entity to repository
                var addedEntity = await _entityRepository.AddEntity(entity);

                var addedEntityResponse = addedEntity.ToEntityResponse();

                // Initialize addedEntityResponse.FeatureItems to a new list
                addedEntityResponse.FeatureItems = new List<FeatureResponse>();

                // add the features to the the repository and associate them to the with the entity
                if (entityRequest.FeatureItems != null)
                {
                    foreach (var item in entityRequest.FeatureItems)
                    {
                        if (item != null)
                        {
                            var feature = item.ToFeature();
                            feature.EntityName = addedEntity.EntityName;

                            var addedFeature = await _featureRepository.AddFeature(feature);

                            if (addedFeature != null)
                            {
                                addedEntityResponse.FeatureItems.Add(addedFeature.ToFeatureResponse());
                            }
                        }
                    }
                }
                return addedEntityResponse;
            }
            else
            {
                // Handle the case when entityRequest is null
                throw new ArgumentNullException(nameof(entityRequest), "Entity request cannot be null");
            }
        }


    }
}
