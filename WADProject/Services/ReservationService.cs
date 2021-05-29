using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WADProject.Models;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class ReservationService : BaseService
    {
        public ReservationService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Reservation> GetReservations()
        {
            return RepositoryWrapper.ReservationRepository.FindAll().ToList();
        }

        public List<Reservation> GetReservationsByCondition(Expression<Func<Reservation, bool>> expression)
        {
            return RepositoryWrapper.ReservationRepository.FindByCondition(expression).ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.Restaurant = RepositoryWrapper.RestaurantRepository.GetFirstRestaurant();
            RepositoryWrapper.ReservationRepository.Create(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            reservation.Restaurant = RepositoryWrapper.RestaurantRepository.GetFirstRestaurant();
            RepositoryWrapper.ReservationRepository.Update(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            reservation.Restaurant = RepositoryWrapper.RestaurantRepository.GetFirstRestaurant();
            RepositoryWrapper.ReservationRepository.Delete(reservation);
        }
    }
}

