using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADProject.Models;
using WADProject.Services;

namespace WADProject.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            var staff = _staffService.GetStaff();
            return View(staff);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = _staffService.GetStaff().FirstOrDefault(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StaffId, Name")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _staffService.AddStaff(staff);
                _staffService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = _staffService.GetStaff().FirstOrDefault(m => m.StaffId == id);
            if (reservations == null)
            {
                return NotFound();
            }
            return View(reservations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StaffId, Name")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _staffService.UpdateStaff(staff);
                    _staffService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(staff.StaffId))
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
            return View(staff);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _staffService.GetStaff().FirstOrDefault(m => m.StaffId == id);
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
            var reservation = _staffService.GetStaffByCondition(b => b.StaffId == id).FirstOrDefault();
            _staffService.DeleteStaff(reservation);
            _staffService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _staffService.GetStaff().Any(e => e.StaffId == id);
        }
    }
}

