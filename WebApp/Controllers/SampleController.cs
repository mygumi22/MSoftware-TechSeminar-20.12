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
        public IActionResult Fruit(int? idx)
        {
            SampleViewModel vm = new SampleViewModel();
            vm.Fruits = db.Fruit.ToList();

            if (idx == null)
            {
                vm.Name = string.Empty;
                vm.ModifyIdx = 0;
            }
            else
            {
                vm.Name = db.Fruit.Find(idx).name;
                vm.ModifyIdx = (int)idx;
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Fruit(SampleViewModel vm)
        {
            if (!string.IsNullOrEmpty(vm.Name))
            {
                if(vm.ModifyIdx == 0)
                {
                    FruitModel fruit = new FruitModel();
                    fruit.name = vm.Name;
                    db.Fruit.Add(fruit);
                    db.SaveChanges();
                }
                else
                {
                    FruitModel fruit = db.Fruit.Find(vm.ModifyIdx);
                    fruit.name = vm.Name;
                    db.Fruit.Update(fruit);
                    db.SaveChanges();
                }
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
