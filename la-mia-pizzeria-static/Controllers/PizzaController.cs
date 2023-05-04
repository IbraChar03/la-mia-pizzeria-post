using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using(PizzaContext pz = new PizzaContext()) {
            List<Pizza> list = pz.Pizzas.ToList();
                if(list == null)
                return View("ErrorList");
                
            return View(list);
            }
   
        }
        public IActionResult Details(int id)
        {
            using(PizzaContext pz = new PizzaContext())
            {
                Pizza pizza = pz.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                return View(pizza);
            }
        }
    }
}
