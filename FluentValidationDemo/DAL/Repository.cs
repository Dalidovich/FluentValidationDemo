using FluentValidationDemo.Domain;
using System;
using System.Security.Principal;

namespace FluentValidationDemo.DAL
{
    public interface IMotherBoardRepository
    {
        public Task<MotherBoard> AddAsync(MotherBoard entity);
        public bool Delete(MotherBoard entity);
        public List<MotherBoard> GetAll();
    }

    public class MotherBoardRepository : IMotherBoardRepository
    {
        public async Task<MotherBoard> AddAsync(MotherBoard entity)
        {
            using (var context = new AppDBContext())
            {
                var addedEntity = await context.MotherBoards.AddAsync(entity);
                await context.SaveChangesAsync();

                return addedEntity.Entity;
            }                
        }

        public bool Delete(MotherBoard entity)
        {
            using (var context = new AppDBContext())
            {
                context.MotherBoards.Remove(entity);
                context.SaveChanges();

                return true;
            }
        }

        public List<MotherBoard> GetAll()
        {
            using (var context = new AppDBContext())
            {

                return context.MotherBoards.ToList();
            }
        }
    }
}
