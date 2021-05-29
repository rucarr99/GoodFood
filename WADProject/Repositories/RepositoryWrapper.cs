using WADProject.Models;

namespace WADProject.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RestaurantContext _restaurantContext;
        private IMenuRepository _menuRepository;
        private IRestaurantRepository _restaurantRepository;
        private IReservationRepository _reservationRepository;
        private IIngredientsRepository _ingredientsRepository;
        private IMenuItemRepository _menuItemRepository;
        private IStaffRepository _staffRepository;
        private IStaffRoleRepository _staffRoleRepository;
        private ICustomUserRepository _customUserRepository;

        public IRestaurantRepository RestaurantRepository => 
            _restaurantRepository ??= new RestaurantRepository(_restaurantContext);

        public IMenuRepository MenuRepository => 
            _menuRepository ??= new MenuRepository(_restaurantContext);

        public IReservationRepository ReservationRepository =>
            _reservationRepository ??= new ReservationRepository(_restaurantContext);

        public IIngredientsRepository IngredientsRepository =>
            _ingredientsRepository ??= new IngredientsRepository(_restaurantContext);

        public IMenuItemRepository MenuItemRepository =>
            _menuItemRepository ??= new MenuItemRepository(_restaurantContext);

        public IStaffRepository StaffRepository =>
            _staffRepository ??= new StaffRepository(_restaurantContext);

        public IStaffRoleRepository StaffRoleRepository =>
            _staffRoleRepository ??= new StaffRoleRepository(_restaurantContext);

        public ICustomUserRepository CustomUserRepository =>
            _customUserRepository ??= new CustomUserRepository(_restaurantContext);


        public RepositoryWrapper(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public void Save()
        {
            _restaurantContext.SaveChanges();
        }

    }
}
