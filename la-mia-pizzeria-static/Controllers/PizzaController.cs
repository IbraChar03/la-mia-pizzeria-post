using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext pz = new PizzaContext()) {
                List<Pizza> list = pz.Pizzas.ToList();
                if (list == null)
                    return View("ErrorList");

                return View(list);
            }

        }
        public IActionResult Details(int id)
        {
            using (PizzaContext pz = new PizzaContext())
            {
                Pizza pizza = pz.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                return View(pizza);
            }
        }

        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(Pizza data)
        {

            if(!ModelState.IsValid)
            {
                return View("Create", data);
            }
            using (PizzaContext context = new PizzaContext())
            {
                Pizza pz = new Pizza { Name = data.Name, Description = data.Description, Image = data.Image, Price = data.Price };
                context.Pizzas.Add(pz);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

    }
}
