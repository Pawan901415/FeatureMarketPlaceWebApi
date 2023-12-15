
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

namespace FeatureMarketPlaceUnitTests
{
    public class FeatureServiceCrudTests
    {



        private readonly IEntityRepository _entityRepository;
        private readonly IFeatureRepository _featureRepository;
        private readonly IFeatureAdderService _featureAdderService;
        private readonly IFeatureGetterService _featureGetterService;
        
        private readonly IFixture _fixture;
        private readonly Mock<IEntityRepository> _entityRepositoryMock;
        private readonly Mock<IFeatureRepository> _featureRepositoryMock;

        public FeatureServiceCrudTests()
        {


            _fixture = new Fixture();
            _entityRepositoryMock = new Mock<IEntityRepository>();
            _entityRepository = _entityRepositoryMock.Object;
            _featureRepositoryMock= new Mock<IFeatureRepository>();
            _featureRepository= _featureRepositoryMock.Object;

            var entitiesInitialData = new List<EntityClass>() { };
            var featuresInitialData = new List<FeatureClass>() { };

            //Craete mock for DbContext
            DbContextMock<ApplicationDbContext> dbContextMock = new DbContextMock<ApplicationDbContext>(
              new DbContextOptionsBuilder<ApplicationDbContext>().Options
             );

            //Access Mock DbContext object
            ApplicationDbContext dbContext = dbContextMock.Object;

            //Create mocks for DbSets'
          
            dbContextMock.CreateDbSetMock(temp => temp.Features);

            //Create services based on mocked DbContext object
            _featureAdderService = new FeatureAdderService(_featureRepository,_entityRepository);

            
            




        }


        //[Fact]
        //public async Task AddFeature_ValidFeature_ShouldReturnFeatureResponse()
        //{
        //    // Arrange
        //    var featureRequest = _fixture.Build<FeatureAddRequest>().Create();
        //    var feature = featureRequest.ToFeature();
        //    var featureResponse = feature.ToFeatureResponse();

        //    _featureRepositoryMock = 
        //        .Setup(repo => repo.AddFeature(It.IsAny<FeatureClass>()))
        //        .ReturnsAsync(feature);

        //    // Act
        //    var actualFeatureResponse = await _featureAdderService.AddFeature(featureRequest);

        //    // Assert
        //    actualFeatureResponse.Should().BeEquivalentTo(featureResponse);
        //}



    }
}

       

