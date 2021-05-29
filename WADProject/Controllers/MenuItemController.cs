using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WADProject.Models;
using WADProject.Repositories;
using WADProject.Services;

namespace WADProject.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly MenuItemService _menuItemService;
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemController(MenuItemService menuItemService, IUnitOfWork unitOfWork)
        {
            _menuItemService = menuItemService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var menuItems = _menuItemService.GetMenuItems();
            return View(menuItems);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = _menuItemService.GetMenuItems().FirstOrDefault(m => m.MenuItemId == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index2()
        {
            var menuItems = _menuItemService.GetMenuItems();
            return View(menuItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MenuItemId, Description, Name, Picture, Price")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _menuItemService.AddMenuItem(menuItem);
                _menuItemService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(menuItem);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = _menuItemService.GetMenuItems().FirstOrDefault(m => m.MenuItemId== id);
            if (reservations == null)
            {
                return NotFound();
            }
            return View(reservations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, [Bind("MenuItemId, Description, Name,")] MenuItem menuItem)
        {
            if (id != menuItem.MenuItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _menuItemService.UpdateMenuItem(menuItem);
                    _menuItemService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(menuItem.MenuItemId))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menuItem);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = _menuItemService.GetMenuItems().FirstOrDefault(m => m.MenuItemId == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        [Authorize(Roles = "Administrator")]

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var menuItem = _menuItemService.GetMenuItems().FirstOrDefault();
            _menuItemService.DeleteMenuItem(menuItem);
            _menuItemService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _menuItemService.GetMenuItems().Any(e => e.MenuItemId== id);
        }
    }
}
