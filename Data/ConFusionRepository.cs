using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConFusion.Data
{
    public class ConFusionRepository: IConFusionRepository
    {
        private readonly ConFusionContext context;

        public ConFusionRepository(ConFusionContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<Dishes[]> GetAllDishesAsync()
        {
            IQueryable<Dishes> query = context.Dishes;

            return await query.ToArrayAsync();
        }

        public async Task<Dishes> GetDishAsync(int id)
        {
            IQueryable<Dishes> query = context.Dishes;

            query.Where(dish => dish.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<Comments[]> GetAllCommentsAsync()
        {
            IQueryable<Comments> query = context.Comments;

            return await query.ToArrayAsync();
        }

        public async Task<Leaders[]> GetAllLeadersAsync()
        {
            IQueryable<Leaders> query = context.Leaders;

            return await query.ToArrayAsync();
        }

        public async Task<Promotions[]> GetAllPromotionsAsync()
        {
            IQueryable<Promotions> query = context.Promotions;

            return await query.ToArrayAsync();
        }
    }
}
