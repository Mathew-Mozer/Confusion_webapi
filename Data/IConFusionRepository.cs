using System;
using System.Threading.Tasks;

namespace ConFusion.Data
{
    public interface IConFusionRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Dishes
        Task<Dishes[]> GetAllDishesAsync();
        Task<Dishes> GetDishAsync(int id);

        //Comments
        Task<Comments[]> GetAllCommentsAsync();

        //Leaders
        Task<Leaders[]> GetAllLeadersAsync();

        //Promotions
        Task<Promotions[]> GetAllPromotionsAsync();
    }
}
