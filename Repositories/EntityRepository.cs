
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using RepositoryContracts;
using System.Runtime.InteropServices;

namespace Repositories
{
    public class EntityRepository : IEntityRepository
    {
        //private readonly ApplicationDbContext _context;

        private readonly TestContext _context;


        public EntityRepository(TestContext context) {
        
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

        public async  Task<EntityClass> GetEntityByName(string EntityName)
        {
            var entity = await _context.Entities.FindAsync(EntityName);

            if (entity == null)
            {

                return null;
            }
            return entity;
        }

        public async  Task<EntityClass> UpdateEntity(EntityClass entity)
        {

            var existingOrder = await _context.Entities.FindAsync(entity.EntityName);
            if (existingOrder == null)
            {
                return entity;
            }
            // Update the properties of the existing entitiy with new values

            existingOrder.EntityName = entity.EntityName;
            existingOrder.Description = entity.Description;

            // save the changes to the database
            await _context.SaveChangesAsync();

            return entity;

            
        }
    }
}