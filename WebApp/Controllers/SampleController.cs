using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SampleController : Controller
    {
        private readonly WebAppDbContext db;

        public SampleController(WebAppDbContext dbContext)
        {
            db = dbContext;
        }


        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Fruit()
        {
            SampleViewModel vm = new SampleViewModel();
            vm.Name = string.Empty;
            vm.Fruits = db.Fruit.ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Fruit(SampleViewModel vm)
        {
            if (!string.IsNullOrEmpty(vm.Name))
            {
                FruitModel fruit = new FruitModel();
                fruit.name = vm.Name;
                db.Fruit.Add(fruit);
                db.SaveChanges();
            }

            return RedirectToAction("Fruit");
        }

        [HttpGet]
        public IActionResult DeleteFruit(int idx)
        {
            var fruit = db.Fruit.Find(idx);
            db.Fruit.Remove(fruit);
            db.SaveChanges();

            return RedirectToAction("Fruit");
        }
    }
}
