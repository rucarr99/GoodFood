using WADProject.Models;

namespace WADProject.Repositories
{
    public interface IRestaurantRepository : IRepositoryBase<Restaurant>
    {
        Restaurant GetFirstRestaurant();
    }
}