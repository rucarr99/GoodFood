using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WADProject.Models;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class IngredientsService : BaseService
    {
        public IngredientsService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Ingredients> GetIngredients()
        {
            return RepositoryWrapper.IngredientsRepository.FindAll().ToList();
        }


        public void AddIngredient(Ingredients ingredients)
        {
            RepositoryWrapper.IngredientsRepository.Create(ingredients);
        }

        public List<Ingredients> GetReservationsByCondition(Expression<Func<Ingredients, bool>> expression)
        {
            return RepositoryWrapper.IngredientsRepository.FindByCondition(expression).ToList();
        }

        public void UpdateIngredient(Ingredients ingredients)
        {
            RepositoryWrapper.IngredientsRepository.Update(ingredients);
        }

        public void DeleteIngredient(Ingredients ingredients)
        {
            RepositoryWrapper.IngredientsRepository.Delete(ingredients);
        }
    }
}
