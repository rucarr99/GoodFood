using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class IngredientsRepository : RepositoryBase<Ingredients>, IIngredientsRepository

    { 
    public IngredientsRepository(RestaurantContext restaurantContext)
        : base(restaurantContext)
    {
    }
}
}
