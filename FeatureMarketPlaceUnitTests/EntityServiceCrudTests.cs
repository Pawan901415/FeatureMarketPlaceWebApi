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

        private readonly IEntityUpdaterService _entityUpdaterService;

        private readonly IEntityDeleterService _entityDeleterService;
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


            _entityDeleterService = new EntityDeleterService(_entityRepository);

            _entityGetterService = new EntityGetterService(_entityRepository);

            _entityUpdaterService=new EntityUpdaterService(_entityRepository);

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



      

        #region DeleteEntity

        [Fact]
        public async Task DeleteEntityByEntityName_WhenEntityExists_ShouldReturnTrue()
        {
            // Arrange
            string entityName = "TestEntity";

            _entityRepositoryMock.Setup(temp => temp.DeleteEntityByEntityName(It.IsAny<string>()))
                .ReturnsAsync(true);

            // Act
            var result = await _entityDeleterService.DeleteEntityByEntityName(entityName);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteEntityByEntityName_WhenEntityDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            string entityName = "TestEntity";

            _entityRepositoryMock.Setup(temp => temp.DeleteEntityByEntityName(It.IsAny<string>()))
                .ReturnsAsync(false);

            // Act
            var result = await _entityDeleterService.DeleteEntityByEntityName(entityName);

            // Assert
            result.Should().BeFalse();
        }

        #endregion


        [Fact]
        public async Task GetEntityByEntityName_WhenEntityExists_ShouldReturnEntityResponse()
        {
            // Arrange
            string entityName = "TestEntity";
            var entity = _fixture.Build<EntityClass>()
                .With(temp => temp.EntityName, entityName)
                .Create();

            _entityRepositoryMock.Setup(temp => temp.GetEntityByName(It.IsAny<string>()))
                .ReturnsAsync(entity);

            // Act
            var result = await _entityGetterService.GetEntityByEntityName(entityName);

            // Assert
            result.Should().BeEquivalentTo(entity.ToEntityResponse());
        }

        [Fact]
        public async Task GetEntityByEntityName_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            string entityName = "TestEntity";

            _entityRepositoryMock.Setup(temp => temp.GetEntityByName(It.IsAny<string>()))
                .ReturnsAsync((EntityClass)null);

            // Act
            var result = await _entityGetterService.GetEntityByEntityName(entityName);

            // Assert
            result.Should().BeNull();
        }

        #region UpdateEntity
        [Fact]
        public async Task UpdateEntity_WhenEntityExists_ShouldReturnUpdatedEntityResponse()
        {
            // Arrange
            string entityName = "TestEntity";
            var updateRequest = _fixture.Build<EntityUpdateRequest>().Create();

            var updatedEntity = _fixture.Build<EntityClass>()
                .With(temp => temp.EntityName, entityName)
                .With(temp=>temp.Description,"testing")
                .Create();

            _entityRepositoryMock.Setup(temp => temp.UpdateEntityAsync(It.IsAny<string>(), It.IsAny<EntityUpdateRequest>()))
                .ReturnsAsync(updatedEntity);

            // Act
            var result = await _entityUpdaterService.UpdateEntity(entityName, updateRequest);

            // Assert
            result.Should().BeEquivalentTo(updatedEntity.ToEntityResponse());
        }

        [Fact]
        public async Task UpdateEntity_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            string entityName = "TestEntity";
            var updateRequest = _fixture.Build<EntityUpdateRequest>().Create();

            _entityRepositoryMock.Setup(temp => temp.UpdateEntityAsync(It.IsAny<string>(), It.IsAny<EntityUpdateRequest>()))
                .ReturnsAsync((EntityClass)null);

            // Act
            var result = await _entityUpdaterService.UpdateEntity(entityName, updateRequest);

            // Assert
            result.Should().BeNull();
        }


        #endregion



        #region GetAllEntities 

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllEntities()
        {
            // Arrange
            var entities = _fixture.CreateMany<EntityClass>(5).ToList();
            _entityRepositoryMock.Setup(temp => temp.GetAllEntities())
                .ReturnsAsync(entities);

            // Act
            var result = await _entityGetterService.GetAllEntities();

            // Assert
            result.Should().BeEquivalentTo(entities.ToEntityResponseList());
        }



        #endregion




    }
}