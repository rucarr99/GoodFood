using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADProject.Models;
using WADProject.Services;

namespace WADProject.Controllers
{
    public class StaffRoleController : Controller
    {
        private readonly StaffRoleService _staffRoleService;

        public StaffRoleController(StaffRoleService staffRoleService)
        {
            _staffRoleService = staffRoleService;
        }

        public IActionResult Index()
        {
            var staffRoles = _staffRoleService.GetStaffRoles();
            return View(staffRoles);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRole = _staffRoleService.GetStaffRoles().FirstOrDefault(m => m.StaffRoleId == id);
            if (staffRole == null)
            {
                return NotFound();
            }

            return View(staffRole);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StaffRoleId, RoleName, RoleDescription")] StaffRole staffRole)
        {
            if (ModelState.IsValid)
            {
                _staffRoleService.AddStaffRole(staffRole);
                _staffRoleService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(staffRole);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRoles = _staffRoleService.GetStaffRoles().FirstOrDefault(m => m.StaffRoleId == id);
            if (staffRoles == null)
            {
                return NotFound();
            }
            return View(staffRoles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StaffRoleId, RoleName, RoleDescription")] StaffRole staffRole)
        {
            if (id != staffRole.StaffRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _staffRoleService.UpdateStaffRole(staffRole);
                    _staffRoleService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffRoleExists(staffRole.StaffRoleId))
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
            return View(staffRole);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRole = _staffRoleService.GetStaffRoles().FirstOrDefault(m => m.StaffRoleId == id);
            if (staffRole == null)
            {
                return NotFound();
            }

            return View(staffRole);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var staffRole = _staffRoleService.GetStaffRolesByCondition(b => b.StaffRoleId == id).FirstOrDefault();
            _staffRoleService.DeleteStaffRole(staffRole);
            _staffRoleService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffRoleExists(int id)
        {
            return _staffRoleService.GetStaffRoles().Any(e => e.StaffRoleId == id);
        }
    }
}
