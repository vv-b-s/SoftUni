using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(true)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                var products = db.Products.OrderBy(p => p.Priority).ToList();
                return View(products);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create() => View();

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Create");
            using (var db = new ShoppingListDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products.First(p => p.Id == id);
                if (product == null)
                    return RedirectToAction("Index");

                return View(product);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Create");

            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products.First(p => p.Id == id);
                product.Name = productModel.Name;
                product.Priority = productModel.Priority;
                product.Quantity = productModel.Quantity;
                product.Status = productModel.Status;
                
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}