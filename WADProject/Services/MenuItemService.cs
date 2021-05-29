using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WADProject.Models;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class MenuItemService : BaseService
    {
        public MenuItemService(IRepositoryWrapper iRepositoryWrapper) 
            : base(iRepositoryWrapper)
        {
        }
        public List<MenuItem> GetMenuItems()
        {
            return RepositoryWrapper.MenuItemRepository.FindAll().ToList();
        }

        public List<Ingredients> GetReservationsByCondition(Expression<Func<Ingredients, bool>> expression)
        {
            return RepositoryWrapper.IngredientsRepository.FindByCondition(expression).ToList();
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            menuItem.Menu= RepositoryWrapper.MenuRepository.GetFirstMenu();
            RepositoryWrapper.MenuItemRepository.Create(menuItem);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            menuItem.Menu = RepositoryWrapper.MenuRepository.GetFirstMenu();
            RepositoryWrapper.MenuItemRepository.Update(menuItem);
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            menuItem.Menu = RepositoryWrapper.MenuRepository.GetFirstMenu();
            RepositoryWrapper.MenuItemRepository.Delete(menuItem);
        }
    }
}
