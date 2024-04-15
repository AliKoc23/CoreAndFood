using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexColumn()
        {
            return View();
        }


        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });

            cs.Add(new Class1()
            {
                proname = "Lcd",
                stock = 100
                
            });

            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 220
            });
            return cs;

        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }

        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();

            using(var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name, 
                    stock = x.Stock
                }).ToList();
            }
          return cs2;
        }


        public IActionResult Statistics()
        {
            Context c = new Context();
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;


            var foid = c.Categories.Where(x => x.CategoryName == "Fruits").Select(y =>
            y.CategoryID).FirstOrDefault();
            var deger3 = c.Foods.Where(x => x.CategoryID == foid).Count();
            ViewBag.d3 = deger3;


            var deger4 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Vegetables").Select(y =>
            y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d6 = deger6;

            var deger7 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d8 = deger8;

            var deger9 = c.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryID).FirstOrDefault();
            var deger9p = c.Foods.Where(y => y.CategoryID == deger9).Sum(x => x.Stock);
            ViewBag.d9 = deger9p;


            var deger10 = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();
            var deger10p = c.Foods.Where(y => y.CategoryID == deger10).Sum(x => x.Stock); 
            ViewBag.d10 = deger10p;

            var deger11 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d11 = deger11;
            return View();
        }

    }
}
