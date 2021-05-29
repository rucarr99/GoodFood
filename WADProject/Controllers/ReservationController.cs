using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADProject.Models;
using WADProject.Services;

namespace WADProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var reservations = _reservationService.GetReservations();
            return View(reservations);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = _reservationService.GetReservations().FirstOrDefault(m => m.ReservationId == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ReservationId,Name,NumberOfPersons,DateApplied,DateOfSchedule")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationService.AddReservation(reservation);
                _reservationService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = _reservationService.GetReservations().FirstOrDefault(m => m.ReservationId == id);
            if (reservations == null)
            {
                return NotFound();
            }
            return View(reservations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ReservationId, Name, NumberOfPersons, DateApplied, DateOfSchedule")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reservationService.UpdateReservation(reservation);
                    _reservationService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservations().FirstOrDefault(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reservation = _reservationService.GetReservationsByCondition(b => b.ReservationId == id).FirstOrDefault();
            _reservationService.DeleteReservation(reservation);
            _reservationService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _reservationService.GetReservations().Any(e => e.ReservationId == id);
        }
    }
}
