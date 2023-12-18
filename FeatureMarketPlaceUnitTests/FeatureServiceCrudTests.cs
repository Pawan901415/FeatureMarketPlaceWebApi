
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
using ServiceContracts.Feature;
using Services.Entity;
using FluentAssertions.Execution;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Services.Feature;
using EntityFrameworkCoreMock;
using Microsoft.Extensions.Logging;
using Xunit.Sdk;

namespace FeatureMarketPlaceUnitTests
{
    public class FeatureServiceCrudTests
    {



        private readonly IEntityRepository _entityRepository;
        private readonly IFeatureRepository _featureRepository;
        private readonly IFeatureAdderService _featureAdderService;
        private readonly IFeatureGetterService _featureGetterService;
        private readonly IFeatureUpdaterService _featureUpdaterService;

        private readonly IFeatureDeleterService _featureDeleterService;
        
        private readonly IFixture _fixture;
        private readonly Mock<IEntityRepository> _entityRepositoryMock;
        private readonly Mock<IFeatureRepository> _featureRepositoryMock;

        public FeatureServiceCrudTests()
        {
            _fixture = new Fixture();
            _entityRepositoryMock = new Mock<IEntityRepository>();
            _entityRepository = _entityRepositoryMock.Object;

            _featureRepositoryMock = new Mock<IFeatureRepository>();
            _featureRepository = _featureRepositoryMock.Object;

           


            _featureAdderService = new FeatureAdderService(_featureRepository,_entityRepository );

            _featureDeleterService = new FeatureDeleterService(_featureRepository);
            _featureUpdaterService=new FeatureUpdaterService(_featureRepository);





        }


        [Fact]
        public async Task AddFeature_WhenEntityDoesNotExist_ShouldAddEntityAndFeature()
        {
            // Arrange
            var featureRequest = _fixture.Build<FeatureAddRequest>()
                .With(temp => temp.EntityName, "TestEntity")
                .With(temp => temp.Description, "TestEntity")
                .Create();

            var entityRequest = new EntityAddRequest
            {
                EntityName = featureRequest.EntityName,
                Description = featureRequest.Description
            };

            var entity = entityRequest.ToEntity();
            var feature = featureRequest.ToFeature();

            _entityRepositoryMock.Setup(temp => temp.GetEntityByName(It.IsAny<string>()))
                .ReturnsAsync((EntityClass)null);

            _entityRepositoryMock.Setup(temp => temp.AddEntity(It.IsAny<EntityClass>()))
                .ReturnsAsync(entity);

            _featureRepositoryMock.Setup(temp => temp.AddFeature(It.IsAny<FeatureClass>()))
                .ReturnsAsync(feature);

            // Act
            var result = await _featureAdderService.AddFeature(featureRequest);

            // Assert
            result.Should().BeEquivalentTo(feature.ToFeatureResponse());
        }

        [Fact]
        public async Task AddFeature_WhenEntityExists_ShouldAddFeatureOnly()
        {
            // Arrange
            var featureRequest = _fixture.Build<FeatureAddRequest>()
                .With(temp => temp.EntityName, "TestEntity")
                .With(temp => temp.Description, "TestEntity")

                .Create();

            var entity = _fixture.Build<EntityClass>()
                .With(temp => temp.EntityName, featureRequest.EntityName)
                .Create();

            var feature = featureRequest.ToFeature();

            _entityRepositoryMock.Setup(temp => temp.GetEntityByName(It.IsAny<string>()))
                .ReturnsAsync(entity);

            _featureRepositoryMock.Setup(temp => temp.AddFeature(It.IsAny<FeatureClass>()))
                .ReturnsAsync(feature);

            // Act
            var result = await _featureAdderService.AddFeature(featureRequest);

            // Assert
            result.Should().BeEquivalentTo(feature.ToFeatureResponse());
        }




        //If we supply a valid feature id, it should return the valid feature details as FeatureResponse object
        [Fact]
        public async Task GetFeatureByFeatureID_WithFeatureID_ToBeSuccessful()
        {
            //Arange
            FeatureClass feature = _fixture.Build<FeatureClass>()
             
            
             .Create();
            FeatureResponse feature_response_expected = feature.ToFeatureResponse();

            _featureRepositoryMock.Setup(temp => temp.GetFeatureByFeatureId(It.IsAny<int>()))
             .ReturnsAsync(feature);

            //Act
            FeatureResponse? feature_response_from_get = await _featureGetterService.GetFeatureByFeatureId(feature.FeatureID);

            //Assert
            feature_response_from_get.Should().Be(feature_response_expected);
        }




        #region DeleteFeature



        [Fact]
        public async Task DeleteFeatureByFeatureId_WhenFeatureExists_ShouldReturnTrue()
        {
            // Arrange
            int featureId = 1;

            _featureRepositoryMock.Setup(temp => temp.DeleteFeatureByFeatureId(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            var result = await _featureDeleterService.DeleteFeatureByFeatureId(featureId);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteFeatureByFeatureId_WhenFeatureDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            int featureId = 1;

            _featureRepositoryMock.Setup(temp => temp.DeleteFeatureByFeatureId(It.IsAny<int>()))
                .ReturnsAsync(false);

            // Act
            var result = await _featureDeleterService.DeleteFeatureByFeatureId(featureId);

            // Assert
            result.Should().BeFalse();
        }


        #endregion


        #region UpdateFeature


        [Fact]
        public async Task UpdateFeature_WhenFeatureExists_ShouldReturnUpdatedFeatureResponse()
        {
            // Arrange
            int featureId = 1;
            var featureRequest = _fixture.Build<FeatureUpdateRequest>().Create();

            var existingFeature = _fixture.Build<FeatureClass>()
                .With(temp => temp.FeatureID, featureId)
                .Create();

            var updatedFeature = new FeatureClass
            {
                FeatureID = existingFeature.FeatureID,
                FeatureName = featureRequest.FeatureName ?? existingFeature.FeatureName,
                Value = featureRequest.Value ?? existingFeature.Value,
                FeatureDataType = featureRequest.FeatureDataType ?? existingFeature.FeatureDataType
            };

            _featureRepositoryMock.Setup(temp => temp.GetFeatureByFeatureId(It.IsAny<int>()))
                .ReturnsAsync(existingFeature);

            _featureRepositoryMock.Setup(temp => temp.UpdateFeature(It.IsAny<FeatureClass>()))
                .ReturnsAsync(updatedFeature);

            // Act
            var result = await _featureUpdaterService.UpdateFeature(featureId, featureRequest);

            // Assert
            result.Should().BeEquivalentTo(updatedFeature.ToFeatureResponse());
        }


        [Fact]
        public async Task UpdateFeature_WhenFeatureDoesNotExist_ShouldThrowException()
        {
            // Arrange
            int featureId = 1;
            var featureRequest = _fixture.Build<FeatureUpdateRequest>().Create();

            _featureRepositoryMock.Setup(temp => temp.GetFeatureByFeatureId(It.IsAny<int>()))
                .ReturnsAsync((FeatureClass)null);

            // Act
            Func<Task> act = async () => { await _featureUpdaterService.UpdateFeature(featureId, featureRequest); };

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Feature not found");
        }


        #endregion


    }
}

       

