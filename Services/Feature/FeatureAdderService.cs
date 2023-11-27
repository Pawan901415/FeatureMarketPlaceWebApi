using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Feature
{
    public class FeatureAdderService : IFeatureAdderService
    {



        private readonly IFeatureRepository _featureRepository;

        private readonly IEntityRepository _entityRepository;




        public FeatureAdderService(IFeatureRepository featureRepository, IEntityRepository entityRepository)
        {
            _featureRepository = featureRepository;
            _entityRepository = entityRepository;
        }
        public async Task<FeatureResponse> AddFeature(FeatureAddRequest featureRequest)
        {
            

            // Convert the request DTO to an Feature entity
            var feature = featureRequest.ToFeature();

            // convert the request dto to Entity Entity

            var isEntityExist = await _entityRepository.GetEntityByName(featureRequest.EntityName);


            if (isEntityExist == null)
            {


                var newEntity = new EntityAddRequest
                {
                    EntityName = featureRequest.EntityName,
                    Description = featureRequest.Description
                };


                var entity = newEntity.ToEntity();

                // add the entity to the repository

                await _entityRepository.AddEntity(entity);
            }

            // Add the feature to the repository


            
            var addedfeature = await _featureRepository.AddFeature(feature);

            

            // Convert the feature item to a response DTO
            return addedfeature.ToFeatureResponse();
        } 
    }
}
