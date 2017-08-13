using System;
using System.Linq;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
	public class TaskController : Controller
	{
	    [HttpGet]
        [Route("")]
	    public ActionResult Index()
	    {
            using (var db = new TodoListDbContext())
            {
                var tasks = db.Tasks.ToList();
                return View(tasks);
            }
                
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create() => View();

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
            using (var db = new TodoListDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

		[HttpGet]
		[Route("delete/{id}")]
        public ActionResult Delete(int id)
		{
            using (var db = new TodoListDbContext())
            {
                try
                {
                    var task = db.Tasks.First(t => t.Id == id);
                    return View(task);
                }
                catch(InvalidOperationException)
                {
                    return RedirectToAction("Index");
                }
            }
        }

		[HttpPost]
		[Route("delete/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(int id)
		{
            using (var db = new TodoListDbContext())
            {
                var task = db.Tasks.First(t => t.Id == id);
                db.Tasks.Remove(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
	}
}