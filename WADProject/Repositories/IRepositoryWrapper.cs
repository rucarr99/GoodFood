using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADProject.Repositories
{
    public interface IRepositoryWrapper
    {
        IRestaurantRepository RestaurantRepository { get; }
        IMenuRepository MenuRepository { get; }
        IReservationRepository ReservationRepository { get; }
        IIngredientsRepository IngredientsRepository { get; }
        IMenuItemRepository MenuItemRepository { get; }
        IStaffRepository StaffRepository { get; }
        IStaffRoleRepository StaffRoleRepository { get; }
        ICustomUserRepository CustomUserRepository { get; }

        void Save();

    }
}
