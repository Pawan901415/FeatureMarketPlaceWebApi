using System;
using System.Collections.Generic;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Moq;
using AutoFixture;
using FluentAssertions;
using RepositoryContracts;
using System.Linq;
using ServiceContracts.Entity;
using Services.Entity;
using FluentAssertions.Execution;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace FeatureMarketPlaceUnitTests
{
    public class EntityServiceCrudTests
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IEntityAdderService _entityAdderService;
        private readonly IEntityGetterService _entityGetterService;
        private readonly IFixture _fixture;
        private readonly Mock<IEntityRepository> _entityRepositoryMock;
        private readonly Mock<IFeatureRepository> _featureRepositoryMock; 

        public EntityServiceCrudTests()
        {
            _fixture = new Fixture();

            _entityRepositoryMock = new Mock<IEntityRepository>();
            _entityRepository = _entityRepositoryMock.Object;

            _featureRepositoryMock = new Mock<IFeatureRepository>(); 
            var _featureRepository = _featureRepositoryMock.Object; 

            _entityAdderService = new EntityAdderService(_entityRepository, _featureRepository);

        }


        //when vaild entity request is given it should return vaild entityresponse object
        #region AddEntity
        [Fact]
        public async Task AddEntity_ValidEntityRequest_ReturnsEntityResponse()
        {
            // Arrange
            var entityRequest = new EntityAddRequest();
            var entity = entityRequest.ToEntity();
            var entityResponse = entity.ToEntityResponse();

            _entityRepositoryMock
                .Setup(repo => repo.GetEntityByName(It.IsAny<string>()))
                .ReturnsAsync((EntityClass)null);

            _entityRepositoryMock
                .Setup(repo => repo.AddEntity(It.IsAny<EntityClass>()))
                .ReturnsAsync(entity);

            _featureRepositoryMock
                .Setup(repo => repo.AddFeature(It.IsAny<FeatureClass>()))
                .ReturnsAsync((FeatureClass feature) => feature);

            // Act
            var result = await _entityAdderService.AddEntity(entityRequest);

            // Assert
            result.Should().BeEquivalentTo(entityResponse);
        }
        //when EntityAddRequest is null it should throw null argument exception
        [Fact]
        public async Task AddEntity_EntityRequestIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            EntityAddRequest entityRequest = null;

            // Act
            Func<Task> act = async () => await _entityAdderService.AddEntity(entityRequest);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }
        //when new entity already exist it should throw ArgumentException

        [Fact]
        public async Task AddEntity_EntityAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var entityRequest = new EntityAddRequest();
            var entity = entityRequest.ToEntity();

            _entityRepositoryMock
                .Setup(repo => repo.GetEntityByName(It.IsAny<string>()))
                .ReturnsAsync(entity);

            // Act
            Func<Task> act = async () => await _entityAdderService.AddEntity(entityRequest);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }

        #endregion


        #region GetAllEnities

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllEntities()
        {
            // Arrange
            var entityList = new List<EntityClass>
    {
        _fixture.Build<EntityClass>()
        .With(temp => temp.Features, null as List<FeatureClass>).Create(),
        _fixture.Build<EntityClass>()
        .With(temp => temp.Features, null as List<FeatureClass>).Create()
    };

            var entityResponseList = entityList.Select(entity => entity.ToEntityResponse()).ToList();

            _entityRepositoryMock
                .Setup(repo => repo.GetAllEntities())
                .ReturnsAsync(entityList);

            // Act
            var actualEntityResponseList = await _entityGetterService.GetAllEntities();

            // Assert
            actualEntityResponseList.Should().BeEquivalentTo(entityResponseList);
        }








        [Fact]
        //If we supply null as EntityName, it should return null as EntityResponse
        public async Task GetEntityByEntityName_NullEntityName_ToBeNull()
        {
            //Arrange
            string ?EntityName = null;

            _entityRepositoryMock
             .Setup(temp => temp.GetEntityByName(It.IsAny<string>()))
             .ReturnsAsync(null as EntityClass);

            //Act
            EntityResponse? entity_response_from_get_method = await _entityGetterService.GetEntityByEntityName(EntityName);


            //Assert
            entity_response_from_get_method.Should().BeNull();
        }

        
        //If we supply a valid EntityName, it should return the matching entity details as EntityResponse object
        [Fact]
        public async Task GetEntityByEntityName_ValidEntityName_ShouldReturnEntityResponse()
        {
            // Arrange
            EntityClass entity = _fixture.Build<EntityClass>()
                .With(temp => temp.Features, null as List<FeatureClass>)
                .Create();
            EntityResponse entityResponse = entity.ToEntityResponse();

            _entityRepositoryMock
                .Setup(temp => temp.GetEntityByName(It.IsAny<string>()))
                .ReturnsAsync(entity); // Return the 'entity' object, not 'EntityClass'

            // Act
            EntityResponse entityResponseFromGet = await _entityGetterService.GetEntityByEntityName(entity.EntityName);

            // Assert
            entityResponseFromGet.Should().BeEquivalentTo(entityResponse);
        }



        #endregion







    }
}