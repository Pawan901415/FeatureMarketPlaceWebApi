
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using RepositoryContracts;
using ServiceContracts.DTO;
using System.Runtime.InteropServices;

namespace Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly ApplicationDbContext _context;

        //private readonly TestContext _context;


        public EntityRepository(ApplicationDbContext context) {
        
        _context = context;
        
        }

        
        public async  Task<EntityClass> AddEntity(EntityClass entity)
        {
            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteEntityByEntityName(string EntityName)
        {
            var entity = await _context.Entities.FindAsync(EntityName);
            if (entity == null) {


                return false;
                    
                    }
            _context.Entities.Remove(entity);

            _context.SaveChangesAsync();
            return true;
            
        }

        public async  Task<List<EntityClass>> GetAllEntities()
        {

            // Retrieve all the entities from the databse,ordered by the entityname in descending order
            var entities=await _context.Entities.OrderByDescending(temp=>temp.EntityName).ToListAsync();

            return entities;
        }

        

        

        public async Task<EntityClass> GetEntityByName(string EntityName)
        {
            var featureItem = await _context.Entities
                .Where(f => f.EntityName.Contains(EntityName))
                .FirstOrDefaultAsync();
            if (featureItem == null)
            {
                return null;
            }

            return featureItem;
        }

        public async Task<List<string>> GetEntityNamesByUserName(string userName)
        {

            return await _context.Features
            .Where(f => f.UserName == userName)
            .Select(f => f.EntityName)
            .ToListAsync();
        }

        public async Task<EntityClass> UpdateEntityAsync(string entityName, EntityUpdateRequest request)
        {

            // Fetch the existing entity from the database
            var existingEntity = await _context.Entities
                .SingleOrDefaultAsync(e => e.EntityName == entityName);

            if (existingEntity == null)
            {
                // Handle the case when the entity is not found
                throw new Exception("Entity not found");
            }

            // Update the properties of the existing entity with new values
            existingEntity.EntityName = request.EntityName;
            existingEntity.Description = request.Description;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return existingEntity;

        }
    }
}