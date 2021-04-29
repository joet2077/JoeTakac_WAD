using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoeTakac_WAD.Data;
using JoeTakac_WAD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JoeTakac_WAD.Controllers
{
    [Authorize(Roles = "Manager")]
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GameController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Game> objList = _db.Game;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Create Entry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game obj)
        {
            if (ModelState.IsValid)
            {
                _db.Game.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Edit ID
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Game.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Edit Entry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Game obj)
        {
            if (ModelState.IsValid)
            {
                _db.Game.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Delete ID
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Game.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Delete Entry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Game obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            _db.Game.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GameDetails(int id)

        {

            Game model = _db.Game.Find(id);

            return View(model);

        }

        public IActionResult Search(String SearchString)

        {
            if (!string.IsNullOrEmpty(SearchString))

            {
                var games = from m in _db.Game

                            where m.Title.Contains(SearchString)

                            select m;

                List<Game> model = games.ToList();

                ViewData["SearchString"] = SearchString;

                return View(model);

            }
            else
            {
                return View();
            }
        }
    }
}
