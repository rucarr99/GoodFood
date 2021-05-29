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
    public class IngredientsController : Controller
    {
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        public IActionResult Index()
        {
            var ingredients = _ingredientsService.GetIngredients();
            return View(ingredients);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredients = _ingredientsService.GetIngredients().FirstOrDefault(m => m.IngredientId == id);
            if (ingredients == null)
            {
                return NotFound();
            }

            return View(ingredients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IngredientId, IngredientName")] Ingredients ingredient)
        {
            if (ModelState.IsValid)
            {
                _ingredientsService.AddIngredient(ingredient);
                _ingredientsService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = _ingredientsService.GetIngredients().FirstOrDefault(m => m.IngredientId == id);
            if (reservations == null)
            {
                return NotFound();
            }
            return View(reservations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IngredientId, IngredientName")] Ingredients ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ingredientsService.UpdateIngredient(ingredient);
                    _ingredientsService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(ingredient.IngredientId))
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
            return View(ingredient);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = _ingredientsService.GetIngredients().FirstOrDefault(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ingredient = _ingredientsService.GetIngredients().FirstOrDefault(m => m.IngredientId == id);
            _ingredientsService.DeleteIngredient(ingredient);
            _ingredientsService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _ingredientsService.GetIngredients().Any(e => e.IngredientId == id);
        }
    }
}
