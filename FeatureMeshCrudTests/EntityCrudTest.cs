using System;
using System.Collections.Generic;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EntityFrameworkCoreMock;
using Moq;
using RepositoryContracts;
using ServiceContracts.Entity;
using Services.Entity;

namespace FeatureMeshCrudTests
{
    public class EntityCrudTest
    {
        private readonly IEntityAdderService _entityAdderService;
        private readonly Mock<IEntityRepository> _entityRepositoryMock;
        private readonly IEntityRepository _entityRepository;

       

        public EntityCrudTest() {


            var entitiesInitialData = new List<EntityClass>() { };

            DbContextMock<ApplicationDbContext> dbContextMock = new DbContextMock<ApplicationDbContext>(
              new DbContextOptionsBuilder<ApplicationDbContext>().Options
             );

            ApplicationDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Entities, entitiesInitialData);

            _entityAdderService = new EntityAdderService(dbContext);
        }


        #region AddEntity

        //When EntityAddRequest is null, it should throw ArgumentNullException

        [Fact]
        public async Task AddEntity_NullEntity()
        {
            //Arrange
            EntityAddRequest? request = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                await _entityAdderService.AddEntity(request);
            });
        }
       

        //When the EntityName is null, it should throw ArgumentException
        [Fact]
        public async Task AddEntity_EntityNameIsNull()
        {
            //Arrange
            EntityAddRequest? request = new EntityAddRequest() { EntityName = null,Description="Test" };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _entityAdderService.AddEntity(request);
            });
        }
        #endregion





    }




}


